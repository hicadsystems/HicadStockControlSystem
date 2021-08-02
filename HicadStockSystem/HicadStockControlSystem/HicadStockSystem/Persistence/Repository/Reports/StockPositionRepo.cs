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

    public class StockPositionRepo : IStockPosition
    {
        private readonly StockControlDBContext _dbContext;

        public StockPositionRepo(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }
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
    }
}
