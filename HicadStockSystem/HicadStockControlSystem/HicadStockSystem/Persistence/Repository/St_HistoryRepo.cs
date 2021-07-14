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
using System.Transactions;

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
            history.RemarkId = 0;

            await TransStoreProc(history);

           /* using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    
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


                    transaction.Commit();
                    //await _uow.CompleteAsync();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }*/
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
            //var stkprice = (from stockmaster in _dbContext.St_StockMasters
            //                where stockmaster.ItemCode == history.ItemCode

            var stkprice = _dbContext.St_StockMasters.Where(x => x.ItemCode == history.ItemCode).Select(y => y.StockPrice).First();
            history.Price = stkprice;
            history.DocType = "RT";
            history.Supplier = "";
            history.UserId = "HICAD3";

            await TransStoreProc(history);

            //using (var transaction = _dbContext.Database.BeginTransaction())
            //{
            //    //                select stockmaster.StockPrice).First();
            //    try
            //    {
            //        //var docNoParam = new SqlParameter("@docno", history.DocNo);
            //        //var itemcodeParam = new SqlParameter("@itemcode", history.ItemCode);
            //        //var trandateParam = new SqlParameter("@trandate", history.DocDate.ToString());
            //        //var quantityParam = new SqlParameter("@quantity", history.Quantity);
            //        //var priceParam = new SqlParameter("@price", stkprice);
            //        //var doctypeParam = new SqlParameter("@doctype", "RT");
            //        //var supcodeParam = new SqlParameter("@supcode", "");
            //        //var unitcodeParam = new SqlParameter("@unitcode", history.Location);
            //        //var user = new SqlParameter("@user", "HICAD3");
            //        //await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
            //        //    docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);

            //        //_dbContext.Update(history);
            //        transaction.Commit();
            //        await _uow.CompleteAsync();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //        throw;
            //    }
            //}
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
            //var stkprice = (from stockmaster in _dbContext.St_StockMasters
            //                where stockmaster.ItemCode == history.ItemCode
            //                select stockmaster.StockPrice).First();
            var docNoParam = new SqlParameter("@docno", history.DocNo);
            var itemcodeParam = new SqlParameter("@itemcode", history.ItemCode);
            var trandateParam = new SqlParameter("@trandate", history.DocDate);
            var quantityParam = new SqlParameter("@quantity", history.Quantity);
            var priceParam = new SqlParameter("@price", history.Price);
            var doctypeParam = new SqlParameter("@doctype", history.DocType);
            var supcodeParam = new SqlParameter("@supcode", history.Supplier);
            var unitcodeParam = new SqlParameter("@unitcode", history.Location);
            var user = new SqlParameter("@user", history.UserId);
            var remark = new SqlParameter("@remark", history.RemarkId);
             await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user,@remark",
                docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user, remark);

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
    }
}
