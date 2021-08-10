using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class DocumentSearchController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IDocumentSearch _search;
        private readonly IGeneratePdf _generatePdf;

        public DocumentSearchController(ISt_StkSystem system, IDocumentSearch search, IGeneratePdf generatePdf)
        {
            _system = system;
            _search = search;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("DocumentSearch/PrintSearchReport/{docNo}")]
        public async Task<IActionResult> PrintSearchReport(string docNo)
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                DocumentSearch = _search.DocumentSearch(docNo)
            };
            return await _generatePdf.GetPdf("Views/DocumentSearch/PrintSearchReport.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
