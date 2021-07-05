using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public class ItemListVM
    {
        public string ItemCode { get; set; }
        public float? Requested { get; set; }
        public string Unit { get; set; }
        public string ItemDescription { get; set; }
        public decimal? Quantity { get; set; }
        //public string RequisitionNo { get; set; }
        public float? currentBalance { get; set; }
    }
}
