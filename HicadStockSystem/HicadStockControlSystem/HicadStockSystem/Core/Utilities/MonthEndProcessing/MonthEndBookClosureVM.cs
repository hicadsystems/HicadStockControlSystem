using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.MonthEndProcessing
{
    public class MonthEndBookClosureVM
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public float? CurrentQty { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }

    }
}
