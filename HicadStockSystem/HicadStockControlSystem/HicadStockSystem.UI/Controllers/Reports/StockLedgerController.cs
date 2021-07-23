using HicadStockSystem.Core.IRespository;
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

        public StockLedgerController(ISt_History history, ISt_StkSystem system)
        {
            _history = history;
            _system = system;
        }
        public IActionResult Index()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                //StockLedgers = _history.StockLedgers().ToList()
                //StockLedgers = _history.StockLedger()
                StockLedgers = _history.GroupByItemCode().ToList()
            };
            return View(ledger);
        }

        public IActionResult StockLedgerPdf()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _history.StockLedgers()
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
