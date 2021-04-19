using HicadStockSystem.Core.Models;
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
        public DbSet<StateList>  StateLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many
            modelBuilder.Entity<StateList>().HasData(
            new StateList { Id = 1, StateName= "Abia" },
            new StateList { Id = 2, StateName = "Adamawa" },
            new StateList { Id = 3, StateName = "Akwa Ibom" },
            new StateList { Id = 4, StateName = "Anambra" },
            new StateList { Id = 5, StateName = "Bauchi" },
            new StateList { Id = 6, StateName = "Bayelsa" },
            new StateList { Id = 7, StateName = "Benue" },
            new StateList { Id = 8, StateName = "Borno" },
            new StateList { Id = 9, StateName = "Cross River" },
            new StateList { Id = 10, StateName = "Delta" },
            new StateList { Id = 11, StateName = "Ebonyi" },
            new StateList { Id = 12, StateName = "Edo" },
            new StateList { Id = 13, StateName = "Ekiti" },
            new StateList { Id = 14, StateName = "Enugu" },
            new StateList { Id = 15, StateName = "FCT - Abuja" },
            new StateList { Id = 16, StateName = "Gombe" },
            new StateList { Id = 17, StateName = "Imo" },
            new StateList { Id = 18, StateName = "Jigawa" },
            new StateList { Id = 19, StateName = "Kaduna" },
            new StateList { Id = 20, StateName = "Kano" },
            new StateList { Id = 21, StateName = "Katsina" },
            new StateList { Id = 22, StateName = "Kebbi" },
            new StateList { Id = 23, StateName = "Kogi" },
            new StateList { Id = 24, StateName = "Kwara" },
            new StateList { Id = 25, StateName = "Lagos" },
            new StateList { Id = 26, StateName = "Nasarawa" },
            new StateList { Id = 27, StateName = "Niger" },
            new StateList { Id = 28, StateName = "Ogun" },
            new StateList { Id = 29, StateName = "Ondo" },
            new StateList { Id = 30, StateName = "Osun" },
            new StateList { Id = 31, StateName = "Oyo" },
            new StateList { Id = 32, StateName = "Plateau" },
            new StateList { Id = 33, StateName = "Rivers" },
            new StateList { Id = 34, StateName = "Sokoto" },
            new StateList { Id = 35, StateName = "Taraba" },
            new StateList { Id = 36, StateName = "Yobe" },
            new StateList { Id = 37, StateName = "Zamfara" });

        }

    }

  
}
