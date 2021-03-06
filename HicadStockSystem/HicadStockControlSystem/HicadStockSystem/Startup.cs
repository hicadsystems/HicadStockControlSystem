using HicadStockSystem.Core;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Persistence;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HicadStockSystem.Mapping;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Persistence.Repository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Persistence.Repository.Reports;
using HicadStockSystem.Core.IRespository.IMonthEndProcessing;
using HicadStockSystem.Persistence.Repository.MonthEndProcess;
using System.IO;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Persistence.Repository.Account;

namespace HicadStockSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
          
            services.AddControllers()
                                .AddNewtonsoftJson(options =>
                                {
                                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                                    {
                                        NamingStrategy = new CamelCaseNamingStrategy()
                                    };
                                    //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                                }); 

            //Entities and there Interfaces
            services.AddScoped<ISt_StkSystem, St_StkSystemRepo>();
            services.AddScoped<ISt_StockMaster, St_StockMasterRepo>();
            services.AddScoped<ISt_StockClass, St_StockClassRepo>();
            services.AddScoped<ISt_BusinessLine, St_BusinessLineRepo>();
            services.AddScoped<ISt_Requisition, St_RequisitionRepo>();
            services.AddScoped<ISt_StkJournal, St_StkJournalRepo>();
            services.AddScoped<ISt_Supplier, St_SupplierRepo>();
            services.AddScoped<ISt_RecordTable, St_RecordTableRepo>();
            services.AddScoped<ISt_ItemMaster, St_ItemMasterRepo>();
            services.AddScoped<ISt_IssueRequisition, St_IssueRequisitionRepo>();
            //services.AddScoped<ISt_IssueApprove, St_IssueApproveRepo>();
            services.AddScoped<ISt_History, St_HistoryRepo>();
            services.AddScoped<ISt_CostCentre, St_CostCentreRepo>();
            services.AddScoped<ISt_BuyerGuide, St_BuyerGuideRepo>();

            services.AddScoped<IAc_BusinessLine, Ac_BusinessLineRepo>();
            services.AddScoped<IAc_CostCentre, Ac_CostCentreRepo>();
            services.AddScoped<ISt_Remark, St_RemarkRepo>();
            //services.AddScoped<IReports, ReportRepo>();
            services.AddScoped<IStockPosition, StockPositionRepo>();
            services.AddScoped<IStockLedger, StockLedgerRepo>();
            services.AddScoped<IReceiptAnalysis, ReceiptAnalysisRepo>();
            services.AddScoped<IIssueToDepartment, IssueToDepartmentRepo>();
            services.AddScoped<IStockConsumption, StockConsumptionRepo>();
            services.AddScoped<IBuyersGuide, BuyersGuideRepo>();
            services.AddScoped<ISlowMovingItems, SlowMovingItemsRepo>();
            services.AddScoped<IOrderRequest, OrderRequestRepo>();
            services.AddScoped<IDocumentSearch, DocumentSearchRepo>();
            services.AddScoped<IRequisitionEnquiry, RequisitionEnquiryRepo>();
            services.AddScoped<IUndeliveredItems, UndeliveredItemsRepo>();
            services.AddScoped<IMonthEndBookClosure, MonthEndBookClosureRepo>();
            services.AddScoped<IPhysicalCountSheet, PhysicalCountSheetRepo>();
            services.AddScoped<IVarianceAnalysis, VarianceAnalysisRepo>();
            services.AddScoped<IOverwriteStockBook, OverwriteStockBookRepo>();

            services.AddScoped<IAuthenticationRepo, AuthenticationRepo>();
            services.AddScoped<IMenuGroupRepo, MenuGroupRepo>();
            services.AddScoped<IMenuRepo, MenuRepo>();
            services.AddScoped<IRoleRepo, RoleRepo>();
            services.AddScoped<IUserRepo, UserService>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<StockControlDBContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));


        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
           builder
           .WithOrigins("http://localhost:8080", "http://localhost:8081")
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
           );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
