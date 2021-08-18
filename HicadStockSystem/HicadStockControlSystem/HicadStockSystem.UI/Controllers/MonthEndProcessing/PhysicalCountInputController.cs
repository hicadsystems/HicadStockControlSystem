using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers.MonthEndProcessing
{
    public class PhysicalCountInputController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
