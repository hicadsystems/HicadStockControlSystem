using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class Ac_CostCentreUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
