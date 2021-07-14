using HicadStockSystem.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class St_StockMasterUIController : Controller
    {
        private readonly ISt_StockMaster _stockMaster;

        public St_StockMasterUIController(ISt_StockMaster stockMaster)
        {
            _stockMaster = stockMaster;
        }
        public async Task<IActionResult> Index()
        {
            var position = await _stockMaster.StockPositions();
            return View(position);
        }

        public IActionResult PrintStockPosition()
        {
            return View();
        }
    }
}
