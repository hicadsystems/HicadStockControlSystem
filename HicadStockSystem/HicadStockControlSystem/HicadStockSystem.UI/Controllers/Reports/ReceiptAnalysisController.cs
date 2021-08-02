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
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class ReceiptAnalysisController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IReceiptAnalysis _analysis;
        private readonly IGeneratePdf _generatePdf;

        public ReceiptAnalysisController(ISt_StkSystem system, IReceiptAnalysis analysis, IGeneratePdf generatePdf)
        {
           
            _system = system;
            _analysis = analysis;
            _generatePdf = generatePdf;
        }

        public IActionResult Index(DateTime startDate, DateTime endDate)
        {
            //_analysis.ReceiptAnalysis(startDate, endDate);
            var analysis = new ReportVM
            {
                Receipts = _analysis.GroupReceiptBySupplier(startDate, endDate),
                Receipts2 = _analysis.GroupReceiptbySum(startDate, endDate),
                StkSystems = _system.GetSingle()
            };
            return View(analysis);
        }

        //public async Task<IActionResult> AnalysisPdf(DateTime startDate, DateTime endDate)
        public IActionResult AnalysisPdf(DateTime startDate, DateTime endDate)
        {
            var analysis = new ReportVM
            {
                Receipts = _analysis.GroupReceiptBySupplier(startDate, endDate),
                Receipts2 = _analysis.GroupReceiptbySum(startDate, endDate),
                StkSystems = _system.GetSingle()
            };
            //return await _generatePdf.GetPdf("Views/ReceiptAnalysis/AnalysisPdf.cshtml", analysis);
            return View(analysis);
        }

        public IActionResult PrintAnalysis()
        {
            var analysis = new ActionAsPdf("AnalysisPdf");
            return analysis;
        }

        public async Task<IActionResult> GetByDate(DateTime startDate, DateTime endDate)
        {
            var result = new ReportVM
            {
                Receipts = _analysis.GroupReceiptBySupplier(startDate, endDate),
                Receipts2 = _analysis.GroupReceiptbySum(startDate, endDate),
                StkSystems = _system.GetSingle()
            };
            return await _generatePdf.GetPdf("Views/ReceiptAnalysis/AnalysisPdf.cshtml", result);
        }
    }
}
