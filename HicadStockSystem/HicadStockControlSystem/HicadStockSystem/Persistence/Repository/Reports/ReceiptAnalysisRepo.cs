using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class ReceiptAnalysisRepo : IReceiptAnalysis
    {
        private readonly StockControlDBContext _dbContext;
       

        public ReceiptAnalysisRepo(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
          
        }

        public IEnumerable<ReceiptAnalysisVM> ReceiptAnalysis(DateTime? startDate, DateTime? endDate)
        {

            var values = (from history in _dbContext.St_Histories
                          join supplier in _dbContext.St_Suppliers on history.Supplier equals supplier.SupplierCode
                          join item in _dbContext.St_ItemMasters on history.ItemCode equals item.ItemCode
                          where history.IsDeleted == false & !history.DocNo.EndsWith("R") && history.DocDate >= startDate && history.DocDate <= endDate
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
        public IEnumerable<ReceiptAnalysisVM> GroupReceiptBySupplier(DateTime? startDate, DateTime? endDate)
        {
            var receipts = new List<ReceiptAnalysisVM>();
            var grp = ReceiptAnalysis(startDate, endDate).OrderBy(x => x.Date).GroupBy(x => x.SupplierCode).ToList();
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
        public IEnumerable<ReceiptAnalysisVM> GroupReceiptbySum(DateTime? startDate, DateTime? endDate)
        {
            var receipts = new List<ReceiptAnalysisVM>();
            var grp = ReceiptAnalysis(startDate, endDate).OrderBy(x => x.Date).DistinctBy(x => x.SupplierCode);

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
    }
}
