using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using HicadStockSystem.Core.Utilities.Report;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<BuyersGuide> BuyersGuide { get; set; }
        public BuyersGuide Guide { get; set; }
        public IEnumerable<SelectListItem> SelectLists { get; set; }
        public IEnumerable<SlowMovingItemsVM> SlowMovingItems { get; set; }
        public SlowMovingItemsVM SlowMovingItem { get; set; }
        public IEnumerable<OrderRequestVM> OrderRequests { get; set; }
        public IEnumerable<UndeliveredItemsVM> UndeliveredItems { get; set; }
        public DocumentSearchVM DocumentSearch { get; set; }
        public RequisitionEnquiryVM RequisitionEnquiry { get; set; }
        public IEnumerable<ReorderList> ReorderLists { get; set; }
        public IEnumerable<MonthEndBookClosureVM> MonthEndBookClosure { get; set; }
        public IEnumerable<PhysicalCountSheetVM>  PhysicalCountSheets { get; set; }
        public IEnumerable<VarianceAnalysisVM> VarianceAnalyses { get; set; }
        public RequesitionVM Requesition { get; set; }

    }
}
