using HicadStockSystem.Core;
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
    public class StockReportController : Controller
    {
        private readonly IStockPosition _stockPosition;
        private readonly ISt_StkSystem _system;
        private readonly IGeneratePdf _generatePdf;

        public StockReportController(IStockPosition stockPosition, ISt_StkSystem system, IGeneratePdf generatePdf)
        {
            _stockPosition = stockPosition;
            _system = system;
            _generatePdf = generatePdf;
        }
        public async Task<IActionResult> Index()
        {
            var position = new ReportVM()
            {
                StockPosition = await _stockPosition.StockPositions(),
                StkSystems = _system.GetSingle()
            };
           
            return View(position);
        }

        [Route("StockReport/StockPositionPdf")]
        public async Task<IActionResult> StockPositionPdf()
        {
            var position = new ReportVM()
            {
                StockPosition = await _stockPosition.StockPositions(),
                StkSystems = _system.GetSingle()
            };
            //var position =  await _stockMaster.StockPositions();
            return await _generatePdf.GetPdf("Views/StockReport/StockPositionPdf.cshtml", position);
        }
        public IActionResult PrintStockPosition()
        {
            var stkposition = new ActionAsPdf("StockPositionPdf");
            return stkposition;
        }
    }
}
