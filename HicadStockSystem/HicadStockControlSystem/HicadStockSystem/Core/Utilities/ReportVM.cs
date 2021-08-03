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
        public ReceiptAnalysisVM ReceiptsAnalysis { get; set; }
        public IEnumerable<ReceiptAnalysisVM> Receipts2 { get; set; }
        public StockLedgerVM Ledgers { get; set; }
        public IEnumerable<StockLedgerVM> StockLedgers { get; set; }
        public IEnumerable<StockLedgerVM> StockLedgers2 { get; set; }
        public IEnumerable<IssuesToDepartment> Issues { get; set; }
        public IEnumerable<IssuesToDepartment> Issues2 { get; set; }
        public IssuesToDepartment IssuesToDept { get; set; }
        public IEnumerable<StockConsumption> Consumptions { get; set; }


    }
}
