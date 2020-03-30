using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AspNetCoreIdentityCustomization.Filters
{
        public class TypeFilterAttribute_TimerElasped : IActionFilter
        {
            public Stopwatch timer;
            private ILogger logger;
      
        private readonly string _value;
      
        public TypeFilterAttribute_TimerElasped(string value, ILoggerFactory loggerFactory)
            {
                 _value = value;
                logger = loggerFactory.CreateLogger<ServiceFilterExample>();
            }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                
                timer = Stopwatch.StartNew();

                logger.LogInformation("Starting Timer now - MethodName " + _value);

            }
            public void OnActionExecuted(ActionExecutedContext context)
            {
                timer.Stop();
                string result = " Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
                logger.LogInformation(result.ToString());

            }
        }
}
