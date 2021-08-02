using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class StockLedgerRepo : IStockLedger
    {
        private readonly StockControlDBContext _dbContext;
        

        public StockLedgerRepo(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }
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
    }
}
