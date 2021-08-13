using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class UndeliveredItemsVM
    {
        public string RequisitionNo { get; set; }
        public string Date { get; set; }
        public string ItemDesc { get; set; }
        public float? Quantity { get; set; }
        public string RequestedBy { get; set; }
        public string ApprovedBy { get; set; }
    }
}
