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

        public IActionResult TestRestSharpClient()
        {
            RestSharpWebApiClient restSharpWebApiClient = new RestSharpWebApiClient("https://prepostlogwebapi.oceanmediainc.com", "US", "National Cable", "Postlog", "b4d153b5-960a-42f8-9397-a893b343a983");
            restSharpWebApiClient.RestClientGetMethod();
            return View();
        }
    }
}
