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
    public class MonthEndBookClosureController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IMonthEndBookClosure _bookClosure;
        private readonly IGeneratePdf _generatePdf;

        public MonthEndBookClosureController(ISt_StkSystem system,IMonthEndBookClosure bookClosure, IGeneratePdf generatePdf)
        {
            _system = system;
            _bookClosure = bookClosure;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("MonthEndBookClosure/BookClosure")]
        public IActionResult BookClosure()
        {
            _bookClosure.BookClosure();
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                MonthEndBookClosure = _bookClosure.GetBookClosure()
            };
            //return RedirectToAction("Index");
            return View("Views/MonthEndBookClosure/BookClosure.cshtml", model);
        }
    }
}
