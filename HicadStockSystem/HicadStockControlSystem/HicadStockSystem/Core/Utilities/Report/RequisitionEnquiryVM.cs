using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class RequisitionEnquiryVM
    {
        public string RequisitionNo { get; set; }
        public string RequestedBy { get; set; }
        public string AprrovedBy { get; set; }
        public string SuppliedBy { get; set; }
        public string RequestDate { get; set; }
        public string ApprovedDate { get; set; }
        public string SupplyDate { get; set; }
        public List<RequestedItems> Items { get; set; }

    }

    public class RequestedItems
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public decimal? ApprovedQty { get; set; }
        public float? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }
    }
}
