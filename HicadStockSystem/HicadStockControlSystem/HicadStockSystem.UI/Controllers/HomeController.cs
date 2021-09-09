using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.UI.Controllers.Account;
using HicadStockSystem.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers
{
    public class HomeController  : BaseController
    {
        private readonly ILogger<HomeController> _logger;
         private readonly IUserRepo _useService;

        public HomeController(ILogger<HomeController> logger, IUserRepo useService) :base(useService)
        {
            _logger = logger;
            _useService = useService;

        }

        public async Task<IActionResult> Index()
        {
            int rd;
            ViewBag.user = User.Identity.Name;
            var currentUser = await GetCurrentUser();

            if (currentUser == null)
            {

                //if (HttpContext.Session.GetString("Message") != null)
                //{
                //    ViewBag.message = HttpContext.Session.GetString("Message");
                //}

                return RedirectToAction("Login","Authentication");
            }
            var role = currentUser.UserRoles;
            foreach (var r in role)
            {
                rd = r.RoleId;
               // HttpContext.Session.SetInt32("roleid", rd);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
