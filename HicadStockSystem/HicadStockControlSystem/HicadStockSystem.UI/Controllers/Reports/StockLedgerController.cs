using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using RotativaCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class StockLedgerController : Controller
    {

        private readonly ISt_History _history;
        private readonly ISt_StkSystem _system;
        private readonly IReports _reports;

        public StockLedgerController(ISt_StkSystem system, IReports reports)
        {

            _system = system;
            _reports = reports;
        }
        public IActionResult Index()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _reports.GroupByItemCode().ToList(),
                StockLedgers2 = _reports.GroupByLastItemCode().ToList()
              
            };
            return View(ledger);
        }

        public IActionResult StockLedgerPdf()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _reports.GroupByItemCode().ToList(),
                StockLedgers2 = _reports.GroupByLastItemCode().ToList()
            };
            return View(ledger);
        }

        public IActionResult PrintStockLedger()
        {
            var ledger = new ActionAsPdf("StockLedgerPdf");
            return ledger;
        }
    }
}
