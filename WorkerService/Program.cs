using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Configure the Serilog to write to a file
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.File(@"C:\Users\tathagat.dwivedi\source\repos\AspNetCoreIdentityCustomization-DevBranch\logs\workerLog.txt")
                .CreateLogger();

            //  var configuration = new ConfigurationBuilder()
            // .AddJsonFile("appsettings.json")
            // .Build();
            //Log.Logger = new LoggerConfiguration()
            //      .ReadFrom.Configuration(configuration)
            //      .CreateLogger();


            try
            {
                //Log.Information("Starting service!");
                Log.Information("Starting service!!");
                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Problem starting service!");

            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                })
                .UseSerilog();
    }
}
