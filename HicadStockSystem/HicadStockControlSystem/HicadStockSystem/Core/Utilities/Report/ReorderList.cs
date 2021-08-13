using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class ReorderList
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public float? Quantity { get; set; }
        public int? ReorderLevel { get; set; }
        public int? ReorderQuantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }

    }
}
