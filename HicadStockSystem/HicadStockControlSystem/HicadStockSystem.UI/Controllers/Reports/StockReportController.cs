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

namespace HicadStockSystem.UI.Controllers.Reports
{
    public class StockReportController : Controller
    {
        private readonly IStockPosition _stockPosition;
        private readonly ISt_StkSystem _system;

        public StockReportController(IStockPosition stockPosition, ISt_StkSystem system)
        {
            _stockPosition = stockPosition;
            _system = system;
        }
        public async Task<IActionResult> Index(/*int? pageNumber*/)
        {
            var position = new ReportVM()
            {
                StockPosition = await _stockPosition.StockPositions(),
                StkSystems = _system.GetSingle()
            };
            //var position = await _stockMaster.StockPositions();
            //int pageSize = 4;
            return View(position/*, Pagination<ReportVM>.Create((IList<ReportVM>)position, pageNumber ?? 1, pageSize)*/);
        }

        public async Task<IActionResult> StockPositionPdf()
        {
            var position = new ReportVM()
            {
                StockPosition = await _stockPosition.StockPositions(),
                StkSystems = _system.GetSingle()
            };
            //var position =  await _stockMaster.StockPositions();
            return View(position);
        }
        public IActionResult PrintStockPosition()
        {
            var stkposition = new ActionAsPdf("StockPositionPdf");
            return stkposition;
        }
    }
}
