using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.IRespository.IReport;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Mapping;
using HicadStockSystem.Persistence;
using HicadStockSystem.Persistence.Repository;
using HicadStockSystem.Persistence.Repository.Reports;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace HicadStockSystem.UI
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
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
                //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            //Entities and there Interfaces
            services.AddWkhtmltopdf("WKHtmlToPdf");
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
            //services.AddScoped<IReports, ReportRepo>();
            services.AddScoped<IStockPosition, StockPositionRepo>();
            services.AddScoped<IStockLedger, StockLedgerRepo>();
            services.AddScoped<IReceiptAnalysis, ReceiptAnalysisRepo>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISt_Remark, St_RemarkRepo>();
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
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
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
