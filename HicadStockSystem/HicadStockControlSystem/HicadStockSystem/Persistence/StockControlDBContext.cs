using HicadStockSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Data
{
    public class StockControlDBContext:IdentityDbContext<User,Role,int>
    {
        public StockControlDBContext(DbContextOptions<StockControlDBContext>options):base(options)
        {
        }
        DbSet<GroupMenu> GroupMenus { get; set; }
        DbSet<RoleMenu> RoleMenus { get; set; }
        DbSet<Menu> Menus { get; set; }
        public DbSet<St_StkSystem> St_StkSystems { get; set; }

    }
}
