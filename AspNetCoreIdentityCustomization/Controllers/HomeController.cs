using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentityCustomization.Models;
using Microsoft.Extensions.Logging;
using AspNetCoreIdentityCustomization.Data;
using AspNetCoreIdentityCustomization.Core;
using AspNetCoreIdentityCustomization.WebApi;
using AspNetCoreIdentityCustomization.WebApi.Client;

namespace AspNetCoreIdentityCustomization.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PostLogRepository _postlogrepository;

        public HomeController(ILogger<HomeController> logger, PostLogRepository postLogRepository)
        {
            _logger = logger;
            _postlogrepository = postLogRepository;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("Hello, {Name}!");
           // PostLogRepository postlog =new PostLogRepository (); 
            PostLog logs;
            logs= _postlogrepository.GetPostLog(1);
            _logger.LogInformation("PostLog-"+ logs.ScheduleName);
            return View();
        }

        public IActionResult About()
        {
            _logger.LogInformation("Hello, {about}!");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // Pre-Postlog Web API Testmethod
        public IActionResult TestRestSharpClient()
        {

            // GAReport API Test

            RestSharpWebApiClient restSharpWebApiClientGaReport = new RestSharpWebApiClient(_logger, "http://localhost:62575/TestGAReportAPIProjet/WeatherForecast");

            restSharpWebApiClientGaReport.RestClientGAReportPostMethod();
            // Pre-PostLog API Test
            RestSharpWebApiClient restSharpWebApiClient = new RestSharpWebApiClient(_logger, "https://prepostlogwebapi.oceanmediainc.com", "US", "National Cable", "Postlog", "fd5ef968-6096-4230-a4dd-7b9ac9eedab0");
            restSharpWebApiClient.RestClientGetMethod();
            return View();
        }
    }
}
