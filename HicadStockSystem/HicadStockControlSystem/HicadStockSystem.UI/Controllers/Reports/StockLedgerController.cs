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

        private readonly ISt_StkSystem _system;
        private readonly IStockLedger _ledger;

        public StockLedgerController(ISt_StkSystem system, IStockLedger ledger)
        {

            _system = system;
            _ledger = ledger;
        }
        public IActionResult Index()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _ledger.GroupByItemCode().ToList(),
                StockLedgers2 = _ledger.GroupByLastItemCode().ToList()
              
            };
            return View(ledger);
        }

        public IActionResult StockLedgerPdf()
        {
            var ledger = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                StockLedgers = _ledger.GroupByItemCode().ToList(),
                StockLedgers2 = _ledger.GroupByLastItemCode().ToList()
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
