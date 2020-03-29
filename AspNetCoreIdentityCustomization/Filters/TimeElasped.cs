using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspNetCoreIdentityCustomization.Filters
{
    public class TimeElasped : IActionFilter
    {
       public Stopwatch timer;
        private  ILogger logger;

        public TimeElasped(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<TimeElasped>();
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
