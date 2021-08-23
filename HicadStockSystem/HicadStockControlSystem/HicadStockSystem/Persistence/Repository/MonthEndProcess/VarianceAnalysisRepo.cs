using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.MonthEndProcess
{
    public class VarianceAnalysisRepo : IVarianceAnalysis
    {
        private readonly StockControlDBContext _context;

        public VarianceAnalysisRepo(StockControlDBContext context)
        {
            _context = context;
        }
        public IEnumerable<VarianceAnalysisVM> GetVarianceAnalysis()
        {
            var variance = _context.St_StockMasters.Where(x => x.IsDeleted == false)
                .Select(y => new VarianceAnalysisVM
                {
                    ItemCode = y.ItemCode,
                    ItemDesc = y.Description,
                    OpenBalance = y.OpenBalance,
                    PhysicalCount = y.Physical,
                    Quantity = y.OpenBalance - y.Physical,
                    StockPrice = y.StockPrice,
                    Value = (decimal)(y.OpenBalance - y.Physical) * y.StockPrice
                }).ToList();
            return variance;
        }
    }
}
