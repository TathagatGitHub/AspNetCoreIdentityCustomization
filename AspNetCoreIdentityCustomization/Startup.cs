﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentityCustomization.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Json;
using AspNetCoreIdentityCustomization.Models;
using Serilog;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using AspNetCoreIdentityCustomization.WebApi.Client;
using RESPApiProject.Controllers;
using AspNetCoreIdentityCustomization.Filters;
using ILogger = Microsoft.Extensions.Logging.ILogger;
//using AspNetCoreIdentityCustomization.RESPApiProject.Filters;



//using Serilog.Events;

namespace AspNetCoreIdentityCustomization
{
    public class Startup
    {
        ILogger _logger;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration).CreateLogger();
            services.AddLogging(logBuilder => logBuilder.AddSerilog(dispose: true));
           

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(
                options => options.Stores.MaxLengthForKeys = 128)
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
         
            services.AddTransient<PostLogRepository>();
             services.AddTransient<PostLogLineRepository>();
          //  services.AddScoped<DCMAdvertiserRepository>();
            services.AddScoped<IRestSharpWebApiClientService, RestSharpWebApiClientService>();
            services.AddTransient<WeatherForecastController>();
          
            services.AddScoped<ServiceFilterExample>(); //ServiceFilterExample Need DI
            services.AddScoped<AsyncActionFilterExample>();//AsyncActionFilterExample
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                 //   IHostingEnvironment env,
                 IWebHostEnvironment env,
                    ApplicationDbContext context,
                    RoleManager<ApplicationRole> roleManager,
                    UserManager<ApplicationUser> userManager)
        {
            // Use when you want to use this middleware ALL the times
            //   app.UseGlobalAPIAuthenticator(); 


            //Use this middleware when want to use only for certain condition.
            //app.UseWhen(context => context.Request.Path.StartsWithSegments(new PathString("/api")), appBuilder =>
            //{
            //   appBuilder.UseGlobalAPIAuthenticator();

            //});
            //OR USE Branching like this, both works
            app.UseWhen(context => context.Request.Path.StartsWithSegments(new PathString("/api")),  branch =>
            {
               // context.Items["tenant"] = tenant
                branch.UseGlobalAPIAuthenticator();

            }) ;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {  
             app.UseExceptionHandler("/Error");
             app.UseHsts();
            }
          
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSerilogRequestLogging();
            app.UseCookiePolicy();

            app.UseAuthentication();
           

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            logger.Information("Hello, world!");

            logger.Information("Starting DummyData");
            DummyData.Initialize(context, userManager, roleManager).Wait();
            app.UseRouting();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
            });



        }
    }
}
