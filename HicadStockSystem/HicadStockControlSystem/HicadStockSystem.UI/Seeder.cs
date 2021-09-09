using HicadStockSystem.Core;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;


namespace HicadStockSystem.UI
{
    public class Seeder
    {
        private static IServiceProvider _provider;
        
        public static void SeedData( RoleManager<Role> roleManager, UserManager<User> userManager, IConfiguration config, IUnitOfWork unitOfWork, StockControlDBContext _dbcontext)
          {

            SeedUsers(userManager, config, unitOfWork, _dbcontext);
            SeedRoles(roleManager);
            SeedMenuGroup(unitOfWork, _dbcontext);
            SeedMenus(unitOfWork, _dbcontext);



        }
        
        public static void SeedRoles(RoleManager<Role> roleManager)
        {
             if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var roles = new List<Role>
                {
                    new Role {Name = "Administrator", IsActive=true, DateCreated= DateTime.Now, Description = "Perform system administrative activities on the APP" },
                    new Role {Name = "Field Officer", Description = "Performs Field Activities on the client portal e.g. verification and enrollment activities",IsActive=true, DateCreated= DateTime.Now},
                     new Role {Name = "Supervisor", Description = "Performs non-administrative, Supervisory roles on the APP ",IsActive=true, DateCreated= DateTime.Now}

                };

                foreach (var role in roles)
                {
                    var result = roleManager.CreateAsync(role).Result;
                }
            }
        }

        public static void SeedMenuGroup(IUnitOfWork unitOfWork, StockControlDBContext _dbcontext)
        {
            var menuGroup = _dbcontext.GroupMenus.Find(1);
            if (menuGroup == null)
            {
                _dbcontext.GroupMenus.Add(new GroupMenu { Name = "Admin", Description = "Administrative Menus", DateCreated = DateTime.Now});
                _dbcontext.GroupMenus.Add(new GroupMenu { Name = "Reports", Description = "Report Menus", DateCreated = DateTime.Now });
                unitOfWork.DoneAsync().Wait();               
            }
        }

        public static void SeedMenus(IUnitOfWork unitOfWork, StockControlDBContext _dbcontext)
        {
            var menu = _dbcontext.Menus.Find(1);
            if (menu == null)
            {
                var menus = new List<Menu>
                {
                    new Menu{Name= "Access Control", Controller="Home", Action="AccessControl", DateCreate =DateTime.Now,  GroupMenuId = 1},
                    new Menu{Name= "User Management", Controller="User", Action="Index",DateCreate =DateTime.Now,  GroupMenuId = 2},
                    //new Menu{Name= "Employee", Controller="Employee", Action="Index",DateCreate =DateTime.Now,  GroupMenuId = 1},
                   
                };

                _dbcontext.Menus.AddRange(menus);
                unitOfWork.DoneAsync().Wait();

                var roleMenus = new List<RoleMenu>
                {
                    new RoleMenu{MenuId = 1, RoleId = 1, DateCreated = DateTime.Now, IsActive = true },
                    new RoleMenu{MenuId = 2, RoleId = 1, DateCreated = DateTime.Now, IsActive = true },
                    new RoleMenu{MenuId = 3, RoleId = 1, DateCreated = DateTime.Now, IsActive = true}
                };

                _dbcontext.RoleMenus.AddRange(roleMenus);
                unitOfWork.DoneAsync().Wait();
            }
        }

        public static void SeedUsers(UserManager<User> userManager, IConfiguration config, IUnitOfWork unitOfWork, StockControlDBContext _dbcontext)
        {
            if (userManager.FindByEmailAsync("hicad@hicad.com").Result == null)
            {
                var user = new User
                {
                    UserName = "hicad@hicad.com",
                    FirstName = "Hicad",
                    LastName = "Hicad1",
                    Email = "hicad@hicad.com",
                    Datecreated = DateTime.Now      
                };

                var result = userManager.CreateAsync(user, "password").Result;
                if (result.Succeeded)
                {
                    _dbcontext.UserRoles.Add(new UserRole
                    {
                        IsActive = true,
                        DateCreated = DateTime.Now,
                        UserId = user.Id,
                        RoleId = 1,

                    });
                    unitOfWork.DoneAsync().Wait();
                }
                
            }
        }


    }

}
