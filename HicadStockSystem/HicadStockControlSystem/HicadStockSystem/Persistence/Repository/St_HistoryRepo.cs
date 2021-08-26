using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Transactions;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_HistoryRepo :  ISt_History
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;
        private readonly string connectionString;

        public St_HistoryRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task CreateAsync(St_History history)
        {
            history.DocType = "GR";
            history.UserId = "HICAD1";
            history.RemarkId = 0;

            await TransStoreProc(history);

        }

        public async Task<IEnumerable<St_History>> GetAll()
        {
            return await _dbContext.St_Histories.Where(h=>h.IsDeleted==false).ToListAsync();
        }

        public IEnumerable<St_History> GetByReceiptNo(string docNo)
        {
            var doc = _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted==false).ToList();
            return doc;
        }

        public async Task UpdateAsync(St_History history)
        {
          

            var stkprice = _dbContext.St_StockMasters.Where(x => x.ItemCode == history.ItemCode).Select(y => y.StockPrice).First();
            history.Price = stkprice;
            history.DocType = "RT";
            history.Supplier = "";
            history.UserId = "HICAD3";

            await TransStoreProc(history);

            
        }

        public async Task UpdateAsync(string itemCode)
        {
            var historyInDb = GetByDocNo(itemCode);
            _dbContext.Update(historyInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string itemCode)
        {
            var historyInDb = GetByDocNo(itemCode);
            historyInDb.IsDeleted=true;
            await _uow.CompleteAsync();
        }

        public async Task<string> GenerateDocNo()
        {
            var date = DateTime.Now.Year.ToString().Substring(2, 2);
            var docCode = "GR" + date + "00000";
            int docNo = 0;
            string genDocNo = "";
            var recordTable = _recordTable.GetByCode("CODE");

            if (recordTable.Code=="CODE" && recordTable.ReceiptNo < 1)
            {
                var doc_No = recordTable.ReceiptNo = docNo + 1;
                genDocNo = docCode + doc_No;
            }
            else if (recordTable.Code=="CODE" && recordTable.ReceiptNo >= 1)
            {
                docNo = recordTable.ReceiptNo;
                var newDocNo = recordTable.ReceiptNo = docNo +1;
                genDocNo = docCode + newDocNo;
            }
            //_recordTable.UpdateAsync(recordTable);
            var docNoParam = new SqlParameter("@receiptno", recordTable.ReceiptNo);
            await _dbContext.Database.ExecuteSqlRawAsync("exec sp_update_receiptno @receiptno", docNoParam);

            return genDocNo;
        }


        public string ReturnNo()
        {

            var date = DateTime.Now.Year.ToString().Substring(2, 2);
            var docCode = "RT" + date + "00000";
            int docNo = 0;
            string genDocNo = "";
            var recordTable = _recordTable.GetByCode("CODE");

            if (recordTable.Code == "CODE" && recordTable.ReturnsNo < 1)
            {
                var doc_No = recordTable.ReturnsNo = docNo + 1;
                genDocNo = docCode + doc_No;
            }
            else if (recordTable.Code == "CODE" && recordTable.ReturnsNo >= 1)
            {
                docNo = recordTable.ReturnsNo;
                var newDocNo = recordTable.ReturnsNo = docNo + 1;
                genDocNo = docCode + newDocNo;

                var docNoParam = new SqlParameter("@returnno", recordTable.ReturnsNo);
                _dbContext.Database.ExecuteSqlRaw("exec sp_update_returnno @returnno", docNoParam);
            }

            

            return genDocNo;
        }

        private async Task TransStoreProc(St_History history)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("st_update_transactions", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@docno", history.DocNo));
                    cmd.Parameters.Add(new SqlParameter("@itemcode", history.ItemCode));
                    cmd.Parameters.Add(new SqlParameter("@trandate", history.DocDate));
                    cmd.Parameters.Add(new SqlParameter("@quantity", history.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@price", history.Price));
                    cmd.Parameters.Add(new SqlParameter("@doctype", history.DocType));
                    cmd.Parameters.Add(new SqlParameter("@supcode", history.Supplier));
                    cmd.Parameters.Add(new SqlParameter("@unitcode", history.Location));
                    cmd.Parameters.Add(new SqlParameter("@user", history.UserId));
                    cmd.Parameters.Add(new SqlParameter("@remark", history.RemarkId));

                    await sqlcon.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
          
           
        }

        public int GetRemarkId(string remark)
        {
            var remarkId = _dbContext.St_Remarks.Where(x => x.Remark == remark).Select(y => y.Id).FirstOrDefault();
            return remarkId;
        }

        public async Task<IEnumerable<St_History>> GetAllReceipt()
        {
            var result = await _dbContext.St_Histories.Where(x => x.DocType == "GR").ToListAsync();
            return result;
        }

        public IEnumerable<string> GetAllReceiptNo()
        {
            var receipts = _dbContext.St_Histories.Where(x => x.IsDeleted == false && x.DocType == "GR" && !x.DocNo.EndsWith("R")).Select(y => y.DocNo).Distinct().ToList();
            return receipts;
        }

        public IEnumerable<St_History> GetItemByReceiptNo(string receiptNo)
        {
            var item = _dbContext.St_Histories.Where(x => x.IsDeleted == false && x.DocNo == receiptNo).ToList();
            return item;
        }

        public St_History GetByDocNo(string docNo)
        {
            var doc = _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted == false).FirstOrDefault();
            return doc;
        }

        public St_History ReverseByItemCode(string docNo, string itemcode)
        {
            var doc = _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted == false && h.ItemCode==itemcode).FirstOrDefault();
            return doc;
        }

        public async Task DeleteReversedReceiptByDocNo(string docNo)
        {
            var receipt = GetByReceiptNo(docNo);
            foreach (var item in receipt)
            {
                item.IsDeleted = true;
            }
            await _uow.CompleteAsync();

        }

        public async Task DeleteReversedItem(string docNo, string itemcode)
        {
            var item = ReverseByItemCode(docNo, itemcode);
            item.IsDeleted = true;
            await _uow.CompleteAsync();
        }

       

      
       
       /* public decimal? getStockPrice(string doctType,decimal? price,int transqty, decimal? currentQty)
        {
            //currentQty = 0m;
            //decimal? value = 0;
            decimal? result = 0M;
            if (doctType == "GR" || doctType == "RT")
            {
              result= currentQty += (price * transqty) / transqty;
               
            }
            else if (doctType.Equals("IS"))
            {
                result = currentQty -= (price * transqty) / transqty;
            }
            return result;
        }*/
        
        
       
      

        private  IEnumerable<St_History> Stocks()
        {
            var items = _dbContext.St_Histories.Where(x => x.IsDeleted == false && !x.DocNo.EndsWith("R"))
                .OrderBy(y=>y.ItemCode)
                .ToList();
            return items;
        }
        
    }
}
