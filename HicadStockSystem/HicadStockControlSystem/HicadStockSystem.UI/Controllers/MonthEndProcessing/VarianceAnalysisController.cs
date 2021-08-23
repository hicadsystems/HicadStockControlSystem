using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.MonthEndProcessing
{
    public class VarianceAnalysisController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IVarianceAnalysis _analysis;
        private readonly IGeneratePdf _generatePdf;

        public VarianceAnalysisController(ISt_StkSystem system, IVarianceAnalysis analysis, IGeneratePdf generatePdf)
        {
            _system = system;
            _analysis = analysis;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Route("VarianceAnalysis/VarianceAnalysisPdf")]
        public async Task<IActionResult> VarianceAnalysisPdf()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                VarianceAnalyses = _analysis.GetVarianceAnalysis()
            };
            //return RedirectToAction("Index");
            return await _generatePdf.GetPdf("Views/VarianceAnalysis/VarianceAnalysisPdf.cshtml", model);
        }


    }
}
