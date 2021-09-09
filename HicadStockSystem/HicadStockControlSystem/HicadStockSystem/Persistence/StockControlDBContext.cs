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
    public  class StockControlDBContext:IdentityDbContext<User,Role,int>
    {
        public StockControlDBContext(DbContextOptions<StockControlDBContext>options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<GroupMenu> GroupMenus { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<St_StkSystem> St_StkSystems { get; set; }
        public DbSet<StateList> StateLists { get; set; }
        public DbSet<St_StockMaster> St_StockMasters { get; set; }
        public DbSet<St_StockClass> St_StockClasses { get; set; }
        public DbSet<St_StkJournal> St_StkJournals { get; set; }
        public DbSet<St_Requisition> St_Requisitions { get; set; }
        public DbSet<St_RecordTable> St_RecordTables { get; set; }
        public DbSet<St_ItemMaster> St_ItemMasters { get; set; }
        public DbSet<St_BuyerGuide> St_BuyerGuides { get; set; }
        public DbSet<St_CostCentre> St_CostCentres { get; set; }
        public DbSet<St_History> St_Histories { get; set; }
        public DbSet<St_BusinessLine> St_BusinessLines { get; set; }
        public DbSet<Ac_CostCentre> Ac_CostCentres { get; set; }
        public DbSet<Ac_BusinessLine> Ac_BusinessLines { get; set; }
        public DbSet<St_Supplier> St_Suppliers { get; set; }
        public DbSet<St_IssueRequisition> St_IssueRequisitions { get; set; }
        public DbSet<St_IssueApprove> St_IssueApproves { get; set; }
        public DbSet<AccChart> AccCharts { get; set; }
        public DbSet<St_Remark> St_Remarks { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<St_StkJournal>().HasKey(j => new
            {
                j.Stk_Company,
                j.Stk_Branch,
                j.Stk_Year,
                j.Stk_Month,
                j.Stk_Location,
                j.Stk_Type,
                j.Stk_Account
            });

            modelBuilder.Entity<St_Requisition>().HasKey(r => new
            {
                r.RequisitionNo,
                r.ItemCode
            });

            modelBuilder.Entity<St_History>().HasKey(h => new
            {
                h.ItemCode,
                h.DocNo,
                h.DocType,
            });

            modelBuilder.Entity<St_IssueApprove>().HasKey(h => new
            {
                h.RequisitionNo,
                h.DocNo,
            });

            modelBuilder.Entity<St_ItemMaster>().HasKey(h => new
            {
                h.ItemCode,
                h.ItemDesc,
            });

            modelBuilder.Entity<St_Remark>().HasKey(h => new
            {
                h.Id,
                h.Remark,
            });

            base.OnModelCreating(modelBuilder);
            //many to many
            //modelBuilder.Entity<StateList>().HasData(
            //new StateList { Id = 1, StateName = "Abia" },
            //new StateList { Id = 2, StateName = "Adamawa" },
            //new StateList { Id = 3, StateName = "Akwa Ibom" },
            //new StateList { Id = 4, StateName = "Anambra" },
            //new StateList { Id = 5, StateName = "Bauchi" },
            //new StateList { Id = 6, StateName = "Bayelsa" },
            //new StateList { Id = 7, StateName = "Benue" },
            //new StateList { Id = 8, StateName = "Borno" },
            //new StateList { Id = 9, StateName = "Cross River" },
            //new StateList { Id = 10, StateName = "Delta" },
            //new StateList { Id = 11, StateName = "Ebonyi" },
            //new StateList { Id = 12, StateName = "Edo" },
            //new StateList { Id = 13, StateName = "Ekiti" },
            //new StateList { Id = 14, StateName = "Enugu" },
            //new StateList { Id = 15, StateName = "FCT - Abuja" },
            //new StateList { Id = 16, StateName = "Gombe" },
            //new StateList { Id = 17, StateName = "Imo" },
            //new StateList { Id = 18, StateName = "Jigawa" },
            //new StateList { Id = 19, StateName = "Kaduna" },
            //new StateList { Id = 20, StateName = "Kano" },
            //new StateList { Id = 21, StateName = "Katsina" },
            //new StateList { Id = 22, StateName = "Kebbi" },
            //new StateList { Id = 23, StateName = "Kogi" },
            //new StateList { Id = 24, StateName = "Kwara" },
            //new StateList { Id = 25, StateName = "Lagos" },
            //new StateList { Id = 26, StateName = "Nasarawa" },
            //new StateList { Id = 27, StateName = "Niger" },
            //new StateList { Id = 28, StateName = "Ogun" },
            //new StateList { Id = 29, StateName = "Ondo" },
            //new StateList { Id = 30, StateName = "Osun" },
            //new StateList { Id = 31, StateName = "Oyo" },
            //new StateList { Id = 32, StateName = "Plateau" },
            //new StateList { Id = 33, StateName = "Rivers" },
            //new StateList { Id = 34, StateName = "Sokoto" },
            //new StateList { Id = 35, StateName = "Taraba" },
            //new StateList { Id = 36, StateName = "Yobe" },
            //new StateList { Id = 37, StateName = "Zamfara" });

            modelBuilder.Entity<St_StkJournal>().Property(u => u.Stk_Debit).HasColumnType("money");
            modelBuilder.Entity<St_StkJournal>().Property(u => u.Stk_Credit).HasColumnType("money");
            modelBuilder.Entity<St_StockMaster>().Property(u => u.StockPrice).HasColumnType("money");
            modelBuilder.Entity<St_Requisition>().Property(r => r.Price).HasColumnType("real");
            modelBuilder.Entity<St_Requisition>().Property(r => r.SupplyQty).HasColumnType("real");
            modelBuilder.Entity<St_IssueRequisition>().Property(i => i.Quantity).HasColumnType("real");
            modelBuilder.Entity<St_IssueRequisition>().Property(i => i.SupplyQty).HasColumnType("real");
            modelBuilder.Entity<St_IssueApprove>().Property(ia => ia.Quantity).HasColumnType("real");
            modelBuilder.Entity<St_IssueApprove>().Property(ia => ia.ApprovedQty).HasColumnType("real");
            modelBuilder.Entity<St_History>().Property(h => h.Price).HasColumnType("money");
            modelBuilder.Entity<St_Supplier>().Property(s => s.Sup_Start_Date).HasColumnType("smalldatetime");

            
           
        }

    }


}
