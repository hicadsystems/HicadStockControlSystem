﻿

using HicadStockSystem.Controllers.ResourcesVM.AcountVM;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NavyAccountWeb.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.UI.Controllers.Account
{
 
    public class RoleController : BaseController
    {
        private readonly IUserRepo userService;
        private readonly IRoleRepo roleService;
        private readonly IMenuRepo menuService;
        public RoleController(IUserRepo userService, IRoleRepo roleService,
            IMenuRepo menuService) : base(userService)
        {
            this.menuService = menuService;
            this.roleService = roleService;
            this.userService = userService;
        }

        public IActionResult Index()
        {
           
            var roles = new RolesViewModel
            {
                Roles = roleService.GetRoles(),
                Menus = menuService.GetMenus()
            };
            return View(roles);
        }

        public async Task<IActionResult> Update(RoleViewModel role)
        {
            if (role.Id > 0)
            {
                var updatedRole = await roleService.GetRoleById(role.Id);
                updatedRole.Name = role.Name;
                updatedRole.Description = role.Description;
                updatedRole.DateCreated = DateTime.Now;
                var response = await roleService.UpdateRoleInfo(updatedRole, role.Menus);
                if (response.Succeeded)
                {
                    TempData["SuccessMessage"] = "Successfully Updated role";
                    return RedirectToAction(nameof(Index));
                }
                TempData["ErrorMessage"] = response.Errors.First().Description;
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Cannot update new role";
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel newRole)
        {
            var role = new Role
            {
                Name = newRole.Name,
                Description = newRole.Description,
                DateCreated = DateTime.Now,
                //UpdatedOn = DateTime.Now,
                IsActive = newRole.Active,
            };
            var success = await roleService.AddRole(role, newRole.Menus);

            if (success)
            {
                TempData["SuccessMessage"] = $"Role {newRole.Name} created Succesfully";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = $"Unable to create Role {newRole.Name}";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/role/togglestatus/{id:int}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            
            var role =  await roleService.GetRoleById(id);

            role.IsActive = !role.IsActive;

            var result = await roleService.UpdateRole(role);

            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = result.Errors.ToList().First().Description;
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = $"Status Change Successful";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/role/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var role = await roleService.GetRoleWithMenuById(id);

            return Json(new
            {
                Role = role,
                Menus = role.RoleMenus.Select(x => x.MenuId)
            }.ToResponse(null, true));
            
        }
    }
}
