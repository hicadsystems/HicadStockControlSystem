using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class ItemViewModel
    {
        public string RequisitionNo { get; set; }
        public string LocationCode { get; set; }
        public string SupplyBy { get; set; }
        public decimal? SupplyQty { get; set; }
        public DateTime? SupplyDate { get; set; }
        public bool IsSupplied { get; set; }
        public string ItemCode { get; set; }
        public float? Requested { get; set; }
        public string Unit { get; set; }
        public string ItemDescription { get; set; }
        public decimal? Quantity { get; set; }
        //public string RequisitionNo { get; set; }
        public float? currentBalance { get; set; }
    }
}
