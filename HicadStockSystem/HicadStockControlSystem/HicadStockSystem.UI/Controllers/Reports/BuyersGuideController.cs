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
    public class BuyersGuideController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IBuyersGuide _guide;
        private readonly IGeneratePdf _generatePdf;

        public BuyersGuideController(ISt_StkSystem system, IBuyersGuide guide, IGeneratePdf generatePdf)
        {
            _system = system;
            _guide = guide;
            _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            ViewBag.buyersGuide = _guide.GetItems();
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                SelectLists = _guide.GetItems()
            };
            return View(model);
        }

      
        [Route("BuyersGuide/GetGuide/{itemCode}")]
        public async Task<IActionResult> GetGuide(string itemCode)
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Guide = _guide.GetSupplierByItemCode(itemCode)
            };
            return await _generatePdf.GetPdf("Views/BuyersGuide/GetGuide.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
