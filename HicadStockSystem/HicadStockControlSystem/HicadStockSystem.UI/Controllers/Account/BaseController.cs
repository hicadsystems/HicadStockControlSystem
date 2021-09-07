using System.Security.Claims;
using System.Threading.Tasks;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace HicadStockSystem.UI.Controllers.Account
{

    public class BaseController : Controller
    {
        private readonly IUserRepo userService;


        public BaseController(IUserRepo userService)
        {
            this.userService = userService;
        }

       
        public string RefererUrl()
        {
            return Request.Headers["Referer"].ToString();
        }

        public async Task<User> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId == null)
            {
                return null;
            }
            return await userService.GetUserWithRoles(int.Parse(userId));            
        }

    }
}