using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class ReceiptAnalysisVM
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string DocNo { get; set; }
        public string Date { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Amount { get; set; }

    }
}
