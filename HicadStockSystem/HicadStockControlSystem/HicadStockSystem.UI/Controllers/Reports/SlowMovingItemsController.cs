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
    public class SlowMovingItemsController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly ISlowMovingItems _slowMoving;
        private readonly IGeneratePdf _generatePdf;

        public SlowMovingItemsController(ISt_StkSystem system, ISlowMovingItems slowMoving, IGeneratePdf generatePdf)
        {
            _system = system;
            _slowMoving = slowMoving;
            _generatePdf = generatePdf;
        }
        public IActionResult Index()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle()
            };
            return View(model);
        }


        [Route("SlowMovingItems/PrintReport/{selectedDate}")]
        public async Task<IActionResult> PrintReport(DateTime? selectedDate)
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                SlowMovingItems = _slowMoving.GetItems(selectedDate)
            };
            return await _generatePdf.GetPdf("Views/SlowMovingItems/PrintReport.cshtml", model);
            //return View("Views/BuyersGuide/GetGuide.cshtml", model);
        }
    }
}
