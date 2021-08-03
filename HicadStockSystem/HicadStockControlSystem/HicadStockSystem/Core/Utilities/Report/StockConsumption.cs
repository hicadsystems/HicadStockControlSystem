using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class StockConsumption
    {
        public string StockCode { get; set; }
        public string StockDescription { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQuantity { get; set; }
        //current qty i.e receipt+openbal-issues
        public float? StockPosition { get; set; }
        public decimal? Amount { get; set; }
        public float? Issues { get; set; }
    }
}
