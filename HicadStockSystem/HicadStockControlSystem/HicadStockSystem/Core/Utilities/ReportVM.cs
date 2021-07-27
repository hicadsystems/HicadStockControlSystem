using HicadStockSystem.Core.Models;
using HicadStockSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class ReportVM
    {
        public IEnumerable<StockPositionVM> StockPosition { get; set; }
        public St_StkSystem StkSystems { get; set; }
        //public StockPositionVM Stock { get; set; }
        public IEnumerable<ReceiptAnalysisVM> Receipts { get; set; }
        public IEnumerable<StockLedgerVM> StockLedgers { get; set; }
        public IEnumerable<StockLedgerVM> StockLedgers2 { get; set; }

    }
}
