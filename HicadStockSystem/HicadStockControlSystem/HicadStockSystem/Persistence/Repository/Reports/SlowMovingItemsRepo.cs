using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class SlowMovingItemsRepo : ISlowMovingItems
    {
        private readonly StockControlDBContext _context;

        public SlowMovingItemsRepo(StockControlDBContext context)
        {
            _context = context;
        }

        public SlowMovingItemsVM GetItem(DateTime? selectedDate, string itemCode)
        {
            var value = _context.St_StockMasters.Where(x => x.IsDeleted == false && x.LastIssueDate < selectedDate && x.ItemCode==itemCode)
                .Join(_context.St_ItemMasters, stock => stock.ItemCode, item => item.ItemCode, (stock, item) => new { stock, item })
                .Select(y => new SlowMovingItemsVM
                {
                    ItemCode = y.item.ItemCode,
                    ItemDesc = y.item.ItemDesc,
                    LastIssueDate = string.Format("{0:MM/dd/yyyy}", y.stock.LastIssueDate),
                    LastIssueQty = y.stock.Issues,
                    CurrentQty = y.stock.OpenBalance + y.stock.Receipts - y.stock.Issues,
                    ReorderLevel = y.item.ReOrderLevel
                }).FirstOrDefault();
            return value;
        }

        public IEnumerable<SlowMovingItemsVM> GetItems(DateTime? selectedDate)
        {
            var value = _context.St_StockMasters.Where(x => x.IsDeleted == false && x.LastIssueDate < selectedDate)
                .Join(_context.St_ItemMasters, stock => stock.ItemCode, item => item.ItemCode, (stock, item) => new { stock, item })
                .Select(y => new SlowMovingItemsVM
                {
                    ItemCode = y.item.ItemCode,
                    ItemDesc = y.item.ItemDesc,
                    LastIssueDate = string.Format("{0:MM/dd/yyyy}", y.stock.LastIssueDate),
                    LastIssueQty = y.stock.Issues,
                    CurrentQty = y.stock.OpenBalance + y.stock.Receipts - y.stock.Issues,
                    ReorderLevel = y.item.ReOrderLevel
                }).ToList();

            return value;
        }
    }
}
