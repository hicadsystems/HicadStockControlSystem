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
    public class ReceiptAnalysisController : Controller
    {
        private readonly ISt_History _history;
        private readonly ISt_StkSystem _system;
        private readonly IReports _reports;

        public ReceiptAnalysisController(ISt_StkSystem system, IReports reports)
        {
           
            _system = system;
            _reports = reports;
        }

        public IActionResult Index()
        {
            var analysis = new ReportVM
            {
                Receipts = _reports.GroupReceiptBySupplier(),
                Receipts2 = _reports.GroupReceiptbySum(),
                StkSystems = _system.GetSingle()
            };
            return View(analysis);
        }

        public IActionResult AnalysisPdf()
        {
            var analysis = new ReportVM
            {
                Receipts = _reports.GroupReceiptBySupplier(),
                Receipts2 = _reports.GroupReceiptbySum(),
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
