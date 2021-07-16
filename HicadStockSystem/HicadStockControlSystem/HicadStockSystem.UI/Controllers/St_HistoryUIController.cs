using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class St_HistoryUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessReturns()
        {
            return View();
        }

        public IActionResult ReturnsRemark()
        {
            return View();
        }


        public IActionResult GetReceipts()
        {
            return View();
        }
        public IActionResult ReceiptReversal()
        {
            return View();
        }
    }
}
