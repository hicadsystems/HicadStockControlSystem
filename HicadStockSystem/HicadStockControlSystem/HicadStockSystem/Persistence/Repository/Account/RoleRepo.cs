
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace NavyAccountWeb.Services
{
    public class RoleRepo : IRoleRepo
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly RoleManager<Role> roleManager;
        private readonly IUnitOfWork unitOfWork;
        public RoleRepo(RoleManager<Role> roleManager, IUnitOfWork unitOfWork, StockControlDBContext dbcontext)
        {
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
        }

        public IEnumerable<Role> GetRoles()
        {
            return roleManager.Roles;
        }

        public IEnumerable<Role> GetActiveRoles()
        {
            return roleManager.Roles.Where(x => x.IsActive);
        }

        public async Task<Role> GetRoleByName(string name)
        {
            return await roleManager.FindByNameAsync(name);
        }


        public async Task<bool> AddRole(Role role, int[] menus)
        {
            var result = await roleManager.CreateAsync(role);

            if (result.Succeeded && menus != null)
            {
                AddMenuToRole(role.Id, menus);
              return  await unitOfWork.DoneAsync();
            }
            return false;
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await roleManager.FindByIdAsync(id.ToString());
        }

        public async Task<Role> GetRoleWithMenuById(int id)
        {
            return await roleManager.Roles.Include(x => x.RoleMenus).FirstOrDefaultAsync(x => x.Id == id);
        }

        private void AddMenuToRole(int roleId, int[] menus)
        {
            if(menus.Length > 0)
            {
                var roleMenus = new List<RoleMenu>();
                foreach (var menu in menus)
                {
                    roleMenus.Add(new RoleMenu
                    {
                        RoleId = roleId,
                        MenuId = menu,
                        DateCreated = DateTime.Now,
                        IsActive = true
                    });
                }
                _dbcontext.RoleMenus.AddRange(roleMenus);
            }          
        }

        public async Task<IdentityResult> UpdateRole(Role role)
        {
           return await roleManager.UpdateAsync(role);
        }

        public async Task<IdentityResult> UpdateRoleInfo(Role role, int[] menus)
        {
            var roleMenus  = _dbcontext.RoleMenus.Where(x => x.RoleId == role.Id);
            _dbcontext.RoleMenus.RemoveRange(roleMenus);

            if (menus != null)
            {
                AddMenuToRole(role.Id, menus);             
            }
            await unitOfWork.CompleteAsync();

            return await roleManager.UpdateAsync(role);
        }
    }
}
