using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.MonthEndProcessing
{
    public class VarianceAnalysisVM
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public float? PhysicalCount { get; set; }
        public float? OpenBalance { get; set; }
        public float? Quantity { get; set; }
        public decimal? StockPrice { get; set; }
        public decimal? Value { get; set; }

    }
}
