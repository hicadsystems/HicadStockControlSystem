using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class ReceiptAnalysisBySupplier
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string ItemDesc { get; set; }
        public int Quantity { get; set; }

    }
}
