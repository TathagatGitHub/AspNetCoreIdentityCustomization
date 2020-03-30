using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspNetCoreIdentityCustomization.Filters
{
    public class ServiceFilterExample : IActionFilter
    {
       public Stopwatch timer;
        private  ILogger logger;

        public ServiceFilterExample(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ServiceFilterExample>();
        }
        public void OnActionExecuting(ActionExecutingContext context) 
        {
           timer = Stopwatch.StartNew();
            logger.LogInformation("Starting Timer now");

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
           timer.Stop();
            string result = " Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
            logger.LogInformation(result.ToString());
          
        }
    }
}
