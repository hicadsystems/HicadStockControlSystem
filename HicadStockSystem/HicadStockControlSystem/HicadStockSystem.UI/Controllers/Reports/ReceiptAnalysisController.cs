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
    public class ReceiptAnalysisController : Controller
    {
        private readonly ISt_History _history;
        private readonly ISt_StkSystem _system;

        public ReceiptAnalysisController(ISt_History history, ISt_StkSystem system)
        {
            _history = history;
            _system = system;
        }

        public async Task<IActionResult> Index()
        {
            var analysis = new ReportVM
            {
                Receipts = await _history.ReceiptAnalysis(),
                StkSystems = _system.GetSingle()
            };
            return View(analysis);
        }

        public async Task<IActionResult> AnalysisPdf()
        {
            var analysis = new ReportVM
            {
                Receipts = await _history.ReceiptAnalysis(),
                StkSystems = _system.GetSingle()
            };
            return View(analysis);
        }

        public IActionResult PrintAnalysis()
        {
            var analysis = new ActionAsPdf("AnalysisPdf");
            return analysis;
        }
    }
}
