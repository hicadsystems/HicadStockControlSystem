using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Reports
{
    public class StockConsumptionRepo : IStockConsumption
    {
        private readonly StockControlDBContext _context;

        public StockConsumptionRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StockConsumption>> Consumptions()
        {
            var result = await _context.St_StockMasters.Where(x => x.IsDeleted == false)
                .Join(_context.St_ItemMasters, stock => stock.ItemCode, item => item.ItemCode, (stock, item) => new { stock, item })
                .Select(y => new StockConsumption
                {
                    StockCode = y.item.ItemCode,
                    StockDescription = y.item.ItemDesc,
                    ReorderLevel = y.item.ReOrderLevel,
                    ReorderQuantity = y.item.ReOrderQty,
                    StockPosition = y.stock.OpenBalance + y.stock.Receipts - y.stock.Issues,
                    Issues = y.stock.Issues
                }).ToListAsync();
            return result;
        }
    }
}
