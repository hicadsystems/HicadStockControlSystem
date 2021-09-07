using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Controllers.ResourcesVM.AcountVM;
using HicadStockSystem.Models;
using HicadStockSystem.UI.Controllers;

namespace HicadStockSystem.UI.Controllers.Account
{
    public class MenuController : BaseController
    {
        private readonly IUserRepo userService;
        private readonly IMenuRepo menuService;
        private readonly IMenuGroupRepo menuGroupService;
        public MenuController(IUserRepo userService, IMenuRepo menuService, IMenuGroupRepo menuGroupService) :base(userService)
        {
            this.menuGroupService = menuGroupService;
            this.menuService = menuService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var devices = new MenusViewModel
            {
                Menus = menuService.GetMenus(),
                MenuGroups = menuGroupService.GetGroupMenuss()
            };
            return View(devices);
        }


        // GET: Menu/Details/5
        [Route("menu/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var menu = await menuService.GetMenuById(id);
            return Ok(new
            {
                Menu = menu
            }); 
        }

        // GET: Menu/Details/5
        [Route("menu/update")]
        public async Task<ActionResult> Update(MenuViewModel newMenu)
        {
            var menu = new Menu
            {
                Id = newMenu.Id,
                Name = newMenu.Name,
                //Code = newMenu.Code,
                //Description = newMenu.Description,
                Controller = newMenu.Controller,
                Action = newMenu.Action,
                IsActive = true
            };

            if (newMenu.MenuGroup.HasValue)
            {
                menu.GroupMenuId = newMenu.Id;
            }
            else {
                menu.GroupMenuId = 0;
            }
            var updated = await menuService.UpdateMenu(menu);

            if (updated)
            {
                TempData["SuccessMessage"] = "Successfully updataed menu";
                return RedirectToAction(nameof(Index));
            }

           // TempData["ErrorMessage"] = "Unable to updataed menu ";
            return RedirectToAction(nameof(Index));
        }

        // GET: Menu/Create
        [Route("/menu/togglestatus/{id:int}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {

            var menu = await menuService.GetMenuById(id);

            menu.IsActive = !menu.IsActive;

            var result =  await menuService.UpdateMenu(menu);

            if (!result)
            {
                //TempData["ErrorMessage"] = "Unable to change menu status";
                return RedirectToAction(nameof(Index));
            }

            //TempData["SuccessMessage"] = $"Status Change Successful";
            return RedirectToAction(nameof(Index));
        }

    }
}