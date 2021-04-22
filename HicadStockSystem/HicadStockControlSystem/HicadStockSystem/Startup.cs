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
                                }); 
            //Entities and there Interfaces
            services.AddScoped<ISt_StkSystem, St_StkSystemRepo>();
            services.AddScoped<ISt_StockMaster, St_StockMasterRepo>();
            services.AddScoped<ISt_StockClass, St_StockClassRepo>();

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
