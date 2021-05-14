using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class St_RequisitionUIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllStockRequest()
        {
            return View();
        }
        public IActionResult GetAllRequisitionForApproval()
        {
            return View();
        }
        public IActionResult GetByCode()
        {
            return View();
        }
    }
}
