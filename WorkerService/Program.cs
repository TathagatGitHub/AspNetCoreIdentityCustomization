using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using WorkerService.Services;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\temp\workerservice\LogFile.txt")
                .CreateLogger();

            try
            {
                Log.Information("Starting up the service");
                //CreateHostBuilder(args).Build().Run();

                using var host = Host.CreateDefaultBuilder(args)
               .UseWindowsService()
               .ConfigureServices((hostContext, services) =>
               {
                   // This section for Queue Service, uncomment the below region to run
                   //#region snippet3 
                   //services.AddSingleton<MonitorLoop>();
                   //services.AddHostedService<QueuedHostedService>();
                   //services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                   //#endregion

                   // This section for Hosted Service, uncomment the below region to run
                   #region snippet1
                   //services.AddHostedService<Worker>();
                   #endregion

                   // This section for Scoped Hosted Service, uncomment the below region to run
                   //#region snippet2
                   ////services.AddHostedService<ConsumeScopedServiceHostedService>();
                   ////services.AddScoped<IScopedProcessingService, ScopedProcessingService>();
                   // #endregion

                   // This section for Timed Hosted Service, uncomment the below region to run
                   //#region snippet4
                   //services.AddHostedService<TimedHostedService>();
                   
                   //#endregion

               })
               .Build();

                host.StartAsync();
               
                // This section for Queue Service, uncomment the below region to run
                //#region snippet4
                //var monitorLoop = host.Services.GetRequiredService<MonitorLoop>();
                //monitorLoop.StartMonitorLoop();
                //#endregion

                host.WaitForShutdownAsync();

                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem starting the serivce");
                return;
            }
            finally
            {
                Log.CloseAndFlush();
            }

            // Message Queue Services
           

        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    // Message Queue Servives
                    services.AddSingleton<MonitorLoop>();
                    services.AddHostedService<QueuedHostedService>();
                    services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
                })
                .UseSerilog();
        }
    }
}
