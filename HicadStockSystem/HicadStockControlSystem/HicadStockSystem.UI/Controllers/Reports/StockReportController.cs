using HicadStockSystem.Core;
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
        private readonly ISt_StockMaster _stockMaster;
        private readonly ISt_StkSystem _system;

        public StockReportController(ISt_StockMaster stockMaster, ISt_StkSystem system)
        {
            _stockMaster = stockMaster;
            _system = system;
        }
        public async Task<IActionResult> Index(/*int? pageNumber*/)
        {
            var position = new ReportVM()
            {
                StockPosition = await _stockMaster.StockPositions(),
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
                StockPosition = await _stockMaster.StockPositions(),
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
