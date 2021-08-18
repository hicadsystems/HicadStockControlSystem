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
    public class PhysicalCountSheetController : Controller
    {
        private readonly ISt_StkSystem _system;
        private readonly IPhysicalCountSheet _countSheet;
        private readonly IGeneratePdf _generatePdf;

        public PhysicalCountSheetController(ISt_StkSystem system, IPhysicalCountSheet countSheet, IGeneratePdf generatePdf)
        {
            _system = system;
            _countSheet = countSheet;
           _generatePdf = generatePdf;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("PhysicalCountSheet/PhysicalCount")]
        public async Task<IActionResult> PhysicalCount()
        {
            var model = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                PhysicalCountSheets = _countSheet.GetCountSheet()
            };
            //return RedirectToAction("Index");
            return await _generatePdf.GetPdf("Views/PhysicalCountSheet/PhysicalCount.cshtml", model);
        }
    }
}
