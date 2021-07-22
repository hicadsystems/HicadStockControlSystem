using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<St_History> GetByReceiptNo(string docNo)
        {
            var doc = _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted==false).ToList();
            return doc;
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

        public async Task<IEnumerable<ReceiptAnalysisVM>> ReceiptAnalysis()
        {
            var values = await _dbContext.St_Histories.Where(x => x.IsDeleted == false && x.DocType == "GR" && !x.DocNo.EndsWith("R"))
                .Join(_dbContext.St_ItemMasters, his => his.ItemCode, item => item.ItemCode, (his, item) => new { his, item })
                .Join(_dbContext.St_Suppliers, hist => hist.his.Supplier, sup => sup.SupplierCode, (hist, sup) => new { hist, sup })
                .Select(y => new ReceiptAnalysisVM
                {
                    SupplierCode = y.hist.his.Supplier,
                    SupplierName = y.sup.Name,
                    DocNo = y.hist.his.DocNo,
                    Date = string.Format("{0:MM/dd/yyyy}", y.hist.his.DocDate) ,
                    ItemDescription = y.hist.item.ItemDesc,
                    Quantity = y.hist.his.Quantity,
                    Price = y.hist.his.Price,
                    Amount = y.hist.his.Quantity * y.hist.his.Price
                }).ToListAsync();

            return values;
        }

        public IEnumerable<StockLedgerVM> StockLedgers()
        {
            //float? curentQty = 0;
            var op = (from his in _dbContext.St_Histories
                      join stk in _dbContext.St_StockMasters on his.ItemCode equals stk.ItemCode
                      where his.IsDeleted == false && !his.DocNo.EndsWith("R")
                      select new StockLedgerVM
                      {
                          ItemCode = stk.ItemCode,
                          ItemDesc = stk.Description,
                          TransDate = string.Format("{0:MM/dd/yyyy}", his.DocDate),
                          TransactionNo = his.DocNo,
                          TransQty = his.Quantity,
                          DocType = his.DocType,
                          //CurrentQty = curentQty += his.Quantity,
                          Price = his.Price,
                          //Value = stk.StockPrice * (decimal)((stk.OpenBalance + stk.Receipts) - stk.Issues)
                          Value = his.Price * his.Quantity
                      });
            return op;
           /* var ledger = new List<StockLedgerVM>();

            var gettotal = op.GroupBy(x => x.ItemCode)
                .Select(g => new StockLedgerVM
                {
                    TransQty = g.Sum(s => s.TransQty),
                    Value = g.Sum(s => s.Value),
                    ItemCode = g.First().ItemCode,
                    ItemDesc = g.First().ItemDesc
                }).OrderBy(g => g.ItemCode);

            return gettotal;*/

            /*var result = await _dbContext.St_Histories.Where(x => x.IsDeleted == false && !x.DocNo.EndsWith("R"))
                .Join(_dbContext.St_StockMasters, his => his.ItemCode, sup => sup.ItemCode, (his, sup) => new { his, sup })
                .Select(y => new StockLedgerVM
                {
                    ItemCode = y.sup.ItemCode,
                    ItemDesc = y.sup.Description,
                    TransDate = string.Format("{0:MM/dd/yyyy}", y.his.DocDate),
                    TransactionNo = y.his.DocNo,
                    TransQty = y.his.Quantity,
                    CurrentQty = (y.sup.OpenBalance + y.sup.Receipts) - y.sup.Issues,
                    Price = y.his.Price,
                    Value = y.sup.StockPrice * (decimal)((y.sup.OpenBalance + y.sup.Receipts) - y.sup.Issues)
                }).OrderBy(y=>y.ItemCode).ToListAsync();

            return (IEnumerable<StockLedgerVM>)result;*/
        }

        private  IEnumerable<St_History> Stocks()
        {
            var items = _dbContext.St_Histories.Where(x => x.IsDeleted == false && !x.DocNo.EndsWith("R"))
                .OrderBy(y=>y.ItemCode)
                .ToList();
            return items;
        }
        //private static DateTime DateOnly(DateTime? dateTime)
        //{
        //    DateTime dateTime1 = DateTime.Now;
        //    dateTime1.ToString("MM/dd/yyyy");
        //    return dateTime1;
        //}
    }
}
