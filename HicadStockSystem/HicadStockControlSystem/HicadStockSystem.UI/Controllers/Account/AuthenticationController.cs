using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using HicadStockSystem.UI.Controllers.Account;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Core;
using HicadStockSystem.Data;
using HicadStockSystem.Controllers.ResourcesVM.AcountVM;
//using System.Collections.Generic;


namespace HicadStockSystem.UI.Controllers.Account
{
    public class AuthenticationController : BaseController
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IAuthenticationRepo authenticationService;
        private readonly IUserRepo userService;

        private readonly IUnitOfWork unitOfWork;

        public AuthenticationController(StockControlDBContext context,IUnitOfWork unitOfWork ,IAuthenticationRepo authenticationService, IUserRepo userService) :base(userService)
        {
            this.userService = userService;
            this.authenticationService = authenticationService;
           
            this.unitOfWork = unitOfWork;
            this._dbcontext = context;
        }

        // GET: Authentication
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            var auth = await authenticationService.SignInUserAsync(login.UserName, login.Password, "false");
            
            if (!auth.Success)
            {
                TempData["ErrorMessage"] = auth.Message;
                return new RedirectResult(RefererUrl());
            }
           


            return RedirectToAction("Index", "Home");
        }

       
        

        public async Task<IActionResult> Logout()
        {
            await authenticationService.SignOutUserAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}