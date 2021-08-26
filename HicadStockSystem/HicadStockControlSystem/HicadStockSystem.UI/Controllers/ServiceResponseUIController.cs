using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class ServiceResponseUIController : Controller
    {
        [Route("ServiceResponseUI/Index/{message}")]
        public IActionResult Index(string message)
        {
            return View(message);
        }
        
    }
}
