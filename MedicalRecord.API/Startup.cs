 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MedicalRecord.Business;
using MedicalRecord.Business.AutoMapper;
using MedicalRecord.Common.AppSettings;
using MedicalRecord.Common.Dto;
using MedicalRecord.DataAccess;
using MedicalRecord.DataAccess.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;

namespace MedicalRecord.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusinessMappingProfile());
            });

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);



            services.Configure<DatabaseConnection>(Configuration.GetSection("ConnectionStrings"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return ConfigureIoC(services);
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.Assembly("MedicalRecord.Business");
                    _.Assembly("MedicalRecord.DataAccess");
                    _.TheCallingAssembly();
                    _.AssemblyContainingType(typeof(Startup));
                    _.WithDefaultConventions();
                    _.LookForRegistries();
                });
                config.For(typeof(IGenericBase<>)).Use(typeof(GenericBase<>));
                //config.For(typeof(IPatientBusiness)).Use(typeof(PatientBusiness));
                config.Populate(services);
            });
             return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseCors();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
