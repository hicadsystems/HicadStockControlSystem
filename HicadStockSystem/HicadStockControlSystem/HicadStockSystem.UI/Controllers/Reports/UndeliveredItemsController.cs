using HicadStockSystem.Core.IRespository.IReport;
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
    public class UndeliveredItemsController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IUndeliveredItems _items;
        private readonly IGeneratePdf _generatePdf;

        public UndeliveredItemsController(ISt_StkSystem system, IUndeliveredItems items, IGeneratePdf generatePdf)
        {
            _system = system;
            _items = items;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("UndeliveredItems/PrintReport")]
        public async Task<IActionResult> PrintReport()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                UndeliveredItems = _items.OrderByDate()
            };
            return await _generatePdf.GetPdf("Views/UndeliveredItems/PrintReport.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
