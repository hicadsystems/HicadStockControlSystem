using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class ReorderListRepo : IReorderList
    {
        private readonly StockControlDBContext _context;

        public ReorderListRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<ReorderList> GetReorderLists()
        {
            //var reorderLevel = GetReorderLevel();

            var result = _context.St_StockMasters
                .Join(_context.St_ItemMasters, stk => stk.ItemCode, item => item.ItemCode, (stk, item) => new { stk, item })
                .Where(x=>x.stk.IsDeleted==false)
                .Select(y => new ReorderList
                {
                    ItemCode = y.item.ItemCode,
                    ItemDesc = y.item.ItemDesc,
                    Quantity = y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues,
                    ReorderLevel = y.item.ReOrderLevel,
                    ReorderQuantity = y.item.ReOrderQty,
                    Price = y.stk.StockPrice,
                    Value = y.item.ReOrderQty * y.stk.StockPrice
                }).Where(y => y.Quantity <= y.ReorderLevel).ToList();

            return result;
        }

        //public IEnumerable<int?> GetReorderLevel()
        //{
        //    var reorderLevel = _context.St_ItemMasters.Where(x => x.IsDeleted == false).Select(y => y.ReOrderLevel).ToList();
        //    return reorderLevel;
        //}
    }
}
