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
    public class StockConsumptionController : Controller
    {
        private readonly IStockConsumption _consumption;
        private readonly ISt_StkSystem _system;
        private readonly IGeneratePdf _generatePdf;

        public StockConsumptionController(IStockConsumption consumption, ISt_StkSystem system, IGeneratePdf generatePdf)
        {
            _consumption = consumption;
            _system = system;
            _generatePdf = generatePdf;
        }

        public async Task<IActionResult> Index()
        {
            var consumption = new ReportVM
            {
                StkSystems = _system.GetSingle(),
                Consumptions = await _consumption.Consumptions()
            };

            return View(consumption);
        }
    }
}
