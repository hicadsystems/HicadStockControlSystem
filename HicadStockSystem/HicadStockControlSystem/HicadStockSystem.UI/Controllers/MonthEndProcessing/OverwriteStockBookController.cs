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
    public class OverwriteStockBookController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IOverwriteStockBook _overwrite;
        private readonly IGeneratePdf _generatePdf;

        public OverwriteStockBookController(ISt_StkSystem system, IOverwriteStockBook overwrite, IGeneratePdf generatePdf)
        {
            _system = system;
            _overwrite = overwrite;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Route("OverwriteStockBook/BookClosure")]
        public async Task<IActionResult> BookClosure()
        {
            _overwrite.OverwriteStockBook();
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                MonthEndBookClosure = _overwrite.OverwriteStock()
            };
            //return RedirectToAction("Index");
            return await _generatePdf.GetPdf("Views/MonthEndBookClosure/BookClosure.cshtml", model);
        }
    }

}
