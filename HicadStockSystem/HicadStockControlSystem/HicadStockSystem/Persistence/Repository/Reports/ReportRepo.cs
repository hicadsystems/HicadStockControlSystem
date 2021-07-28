using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class ReportRepo : IReports
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;

        public ReportRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
        }

        //stock position report
        public async Task<IEnumerable<StockPositionVM>> StockPositions()
        {
            var values = await _dbContext.St_StockMasters.Where(x => x.IsDeleted == false)
                .Join(_dbContext.St_ItemMasters, stk => stk.ItemCode, item => item.ItemCode, (stk, item) => new { stk, item })
                .Select(y => new StockPositionVM
                {
                    ItemCode = y.stk.ItemCode,
                    ItemDesc = y.stk.Description,
                    PartNo = y.item.PartNo,
                    CurrentBalance = y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues,
                    Price = y.stk.StockPrice,
                    Value = y.stk.StockPrice * (decimal)(y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues)
                }).ToListAsync();

            return values;
        }

        //Receipt Analysis Report
        public IEnumerable<ReceiptAnalysisVM> ReceiptAnalysis()
        {

            var values = (from history in _dbContext.St_Histories
                          join supplier in _dbContext.St_Suppliers on history.Supplier equals supplier.SupplierCode
                          join item in _dbContext.St_ItemMasters on history.ItemCode equals item.ItemCode
                          where history.IsDeleted == false & !history.DocNo.EndsWith("R")
                          select new ReceiptAnalysisVM
                          {
                              SupplierCode = supplier.SupplierCode,
                              SupplierName = supplier.Name,
                              DocNo = history.DocNo,
                              Date = string.Format("{0:MM/dd/yyyy}", history.DocDate),
                              ItemDescription = item.ItemDesc,
                              Quantity = history.Quantity,
                              Price = history.Price,
                              Amount = history.Quantity * history.Price
                          }).ToList();

            return values;
        }

        public IEnumerable<ReceiptAnalysisVM> GroupReceiptBySupplier()
        {
            var receipts = new List<ReceiptAnalysisVM>();
            var grp = ReceiptAnalysis().OrderBy(x => x.Date).GroupBy(x => x.SupplierCode).ToList();
            foreach (var g in grp)
            {
                foreach (var receipt in g)
                {
                    receipts.Add(new ReceiptAnalysisVM
                    {
                        SupplierCode = receipt.SupplierCode,
                        SupplierName = receipt.SupplierName,
                        Date = receipt.Date,
                        DocNo = receipt.DocNo,
                        ItemDescription = receipt.ItemDescription,
                        Quantity = receipt.Quantity,
                        Price = receipt.Price,
                        Amount = receipt.Amount
                    });
                }

            }
            return receipts;
        }
        public IEnumerable<ReceiptAnalysisVM> GroupReceiptbySum()
        {
            var receipts = new List<ReceiptAnalysisVM>();
            var grp = ReceiptAnalysis().OrderBy(x => x.Date).DistinctBy(x => x.SupplierCode);

            foreach (var receipt in grp)
            {
                receipts.Add(new ReceiptAnalysisVM
                {
                    SupplierCode = receipt.SupplierCode,
                    SupplierName = receipt.SupplierName,
                    Date = receipt.Date,
                    DocNo = receipt.DocNo,
                    ItemDescription = receipt.ItemDescription,
                    Quantity = receipt.Quantity,
                    Price = receipt.Price,
                    Amount = receipt.Amount
                });
            }


            return receipts;
        }

        //Stock Ledger Report
        public IEnumerable<StockLedgerVM> StockLedger()
        {
            var stocks = new List<StockLedgerVM>();
            stocks = (from his in _dbContext.St_Histories
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
                          Price = his.Price,
                          DateCreated = his.DateCreated
                      }).ToList();

            return stocks;
        }

        public IEnumerable<StockLedgerVM> GroupByItemCode()
        {
            decimal? currentQty = 0m;
            decimal? value = 0m;
            decimal? stockqty = 0m;
            List<StockLedgerVM> stkgrp = new List<StockLedgerVM>();
            //var lg = new StockLedgerVM();
            var grp = StockLedger().OrderBy(x => x.TransDate).GroupBy(x => x.ItemCode).ToList();

            foreach (var g in grp)
            {
                currentQty = 0;
                value = 0;

                foreach (var gr in g)
                {

                    stkgrp.Add(new StockLedgerVM
                    {
                        ItemCode = gr.ItemCode,
                        ItemDesc = gr.ItemDesc,
                        TransactionNo = gr.TransactionNo,
                        Price = gr.Price,
                        //Price = gr.DocType.Equals("GR") || gr.DocType.Equals("RT") || gr.DocType.Equals("IS") ? gr.Price : null,
                        TransQty = gr.DocType.Equals("GR") || gr.DocType.Equals("RT") || gr.DocType.Equals("IS") ? gr.TransQty : null,
                        DocType = gr.DocType,
                        TransDate = gr.TransDate,
                        StockQuantity = stockqty = gr.DocType.Equals("GR") || gr.DocType.Equals("RT") ? currentQty += gr.TransQty
                        : gr.DocType.Equals("IS") ? currentQty -= gr.TransQty : gr.TransQty,
                        Value = gr.DocType.Equals("GR") || gr.DocType.Equals("RT") ? value += (gr.Price * gr.TransQty)
                        : gr.DocType.Equals("IS") ? value -= (gr.Price * gr.TransQty) : gr.Price * gr.TransQty,
                        StockPrice = gr.DocType.Equals("GR") || gr.DocType.Equals("RT") || gr.DocType.Equals("IS") ? value / stockqty : gr.Price
                    });

                }


            }

            return stkgrp;
        }

        public IEnumerable<StockLedgerVM> GroupByLastItemCode()
        {
            List<StockLedgerVM> stkgrp = new List<StockLedgerVM>();
            //var lg = new StockLedgerVM();
            var grp = StockLedger().OrderBy(x => x.TransDate).DistinctBy(x => x.ItemCode);

            foreach (var g in grp)
            {


                stkgrp.Add(new StockLedgerVM
                {
                    ItemCode = g.ItemCode,
                    ItemDesc = g.ItemDesc,
                    TransactionNo = g.TransactionNo,
                    Price = g.Price,
                    TransQty = g.TransQty,
                    DocType = g.DocType,
                    TransDate = g.TransDate,
                    StockPrice = g.StockPrice
                });

            }

            return stkgrp;
        }

        public IEnumerable<StockLedgerVM> Issues()
        {
            var stocks = new List<StockLedgerVM>();
            stocks = (from his in _dbContext.St_Histories
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
                          Price = his.Price,
                          DateCreated = his.DateCreated
                      }).ToList();

            return stocks;
        }
    }
}
