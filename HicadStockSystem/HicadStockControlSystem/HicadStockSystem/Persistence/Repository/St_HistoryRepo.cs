using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_HistoryRepo :  ISt_History
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;

        public St_HistoryRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
        }
        public async Task CreateAsync(St_History history)
        {
            history.DocType = "GR";
            history.UserId = "HICAD1";
           
            await TransStoreProc(history);
            //var docNoParam = new SqlParameter("@docno", history.DocNo);
            //var itemcodeParam = new SqlParameter("@itemcode", history.ItemCode);
            //var trandateParam = new SqlParameter("@trandate", history.DocDate.ToString());
            //var quantityParam = new SqlParameter("@quantity", history.Quantity);
            //var priceParam = new SqlParameter("@price",history.Price);
            //var doctypeParam = new SqlParameter("@doctype", history.DocType);
            //var supcodeParam = new SqlParameter("@supcode", history.Supplier);
            //var unitcodeParam = new SqlParameter("@unitcode", history.Location);
            //var user = new SqlParameter("@user", history.UserId);
            //await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
            //    docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);

            //await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
            //    docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);


            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_History>> GetAll()
        {
            return await _dbContext.St_Histories.Where(h=>h.IsDeleted==false).ToListAsync();
        }

        public St_History GetByDocNo(string docNo)
        {
            return _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_History history)
        {
            var stkprice = (from stockmaster in _dbContext.St_StockMasters
                            where stockmaster.ItemCode == history.ItemCode
                            select stockmaster.StockPrice).First();
            history.Price = stkprice;
            history.DocType = "RT";
            history.Supplier = "";
            history.UserId = "HICAD3";

            await TransStoreProc(history);

            //var docNoParam = new SqlParameter("@docno", history.DocNo);
            //var itemcodeParam = new SqlParameter("@itemcode", history.ItemCode);
            //var trandateParam = new SqlParameter("@trandate", history.DocDate.ToString());
            //var quantityParam = new SqlParameter("@quantity", history.Quantity);
            //var priceParam = new SqlParameter("@price", stkprice);
            //var doctypeParam = new SqlParameter("@doctype", "RT");
            //var supcodeParam = new SqlParameter("@supcode", "");
            //var unitcodeParam = new SqlParameter("@unitcode", history.Location);
            //var user = new SqlParameter("@user", "HICAD3");
            //await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
            //    docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);

            //_dbContext.Update(history);
            await _uow.CompleteAsync();
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

        public string GenerateDocNo()
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
            }

            return genDocNo;
        }

        private async Task TransStoreProc(St_History history)
        {
            //var stkprice = (from stockmaster in _dbContext.St_StockMasters
            //                where stockmaster.ItemCode == history.ItemCode
            //                select stockmaster.StockPrice).First();
            var docNoParam = new SqlParameter("@docno", history.DocNo);
            var itemcodeParam = new SqlParameter("@itemcode", history.ItemCode);
            var trandateParam = new SqlParameter("@trandate", history.DocDate.ToString());
            var quantityParam = new SqlParameter("@quantity", history.Quantity);
            var priceParam = new SqlParameter("@price", history.Price);
            var doctypeParam = new SqlParameter("@doctype", history.DocType);
            var supcodeParam = new SqlParameter("@supcode", history.Supplier);
            var unitcodeParam = new SqlParameter("@unitcode", history.Location);
            var user = new SqlParameter("@user", history.UserId);
             await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
                docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);

        }
    }
}
