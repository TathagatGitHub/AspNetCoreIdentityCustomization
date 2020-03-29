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
using AspNetCoreIdentityCustomization.Filters;
using RESPApiProject.Controllers;
using RESPApiProject;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreIdentityCustomization.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PostLogRepository _postlogrepository;
        private WeatherForecastController _weatherForecastController;
        private const string ApiClientName = "Hims";
        public IHttpContextAccessor _httpContext { get; set; }
        public HomeController(ILogger<HomeController> logger, PostLogRepository postLogRepository, WeatherForecastController weatherForecastController, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _postlogrepository = postLogRepository;
            _weatherForecastController = weatherForecastController;
            _httpContext = httpContext;
        }
        [HttpsOnly]
        public IActionResult Index()
        {
           //throw new Exception("Error from Index");  
            _logger.LogInformation("Inside the Index view");
           // PostLogRepository postlog =new PostLogRepository (); 
            //PostLog logs;
            //logs= _postlogrepository.GetPostLog(1);
            //_logger.LogInformation("PostLog-"+ logs.ScheduleName);
            return View();
        }

        //[TimeElasped(ILogger < TimeElasped > _logger)]
        [ServiceFilter(typeof(TimeElasped))]
      // [TypeFilter(typeof(TimeElasped))]
        public IActionResult PostLogList()
        {
            ViewBag._logger = _logger;
           // throw new Exception();
            _logger.LogInformation("Inside the PostLogView");
            // PostLogRepository postlog =new PostLogRepository (); 
            IEnumerable<PostLog> logs;
            //logs = _postlogrepository.GetPostLog(1);
            logs = _postlogrepository.GetPostLogList();
            _logger.LogInformation("PostLog-" + logs.ToList());
          //  var TimeElasped = _httpContext.HttpContext.Items["TimeElasped"];
           // _logger.LogInformation(TimeElasped.ToString());
            return View(logs);
        }

        public IActionResult GlobalExceptionMethod()
        {
            throw new Exception();
       
            
        }

        [TypeFilter(typeof(ExceptionFilter))]
        public IActionResult ExceptionFilterMethod()
        {
            _logger.LogInformation("Inside the ExceptionFilterMethod");
            throw new NotImplementedException();
        }

        [ApiKeyAuth]
        [HttpGet("RequestRestApiProjectweatherAPI")]
        public void RequestRestApiProjectweatherAPI()
        {

            var ClientName = _httpContext.HttpContext.Items["ClientName"];
            IEnumerable<WeatherForecast> weatherForecasts;
            weatherForecasts = _weatherForecastController.GetweatherList();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // Pre-Postlog Web API Testmethod
        [HttpGet("TestRestSharpClient")]
        public IActionResult TestRestSharpClient()
        {

            
            // Pre-PostLog API Test
            RestSharpWebApiClient restSharpWebApiClient = new RestSharpWebApiClient(_logger, "https://prepostlogwebapi.oceanmediainc.com", "US", "National Cable", "Postlog", "fd5ef968-6096-4230-a4dd-7b9ac9eedab0");
            restSharpWebApiClient.RestClientGetMethod();
            return View();
        }

        // GAReports Test Client
        public IActionResult GAReportRestSharpClient()
        {

            // GAReport API Test
            //    string APIUrl = "http://localhost:62575/WeatherForecast";
            //  string APIUrl = "http://localhost:62575/WeatherForecast";
         //   string APIUrl = "http://localhost:62575/WeatherForecast/TestAPIClient";
            
            string APIUrl = "http://localhost:62575/WeatherForecast/TestGAReportAPIRequest";



            RestSharpWebApiClient restSharpWebApiClientGaReport = new RestSharpWebApiClient(_logger,
                APIUrl);

            

            restSharpWebApiClientGaReport.RestClientGAReportPostMethod();
            
            return View();
        }

        //[RequireHttps]
        [HttpsOnly]
        [HttpGet("RequireHttpsOnly")]
        public IActionResult RequireHttpsOnly ()
        {
            return View();
        }

    }
}
