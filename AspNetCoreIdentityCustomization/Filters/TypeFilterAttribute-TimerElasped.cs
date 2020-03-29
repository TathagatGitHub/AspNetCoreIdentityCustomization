using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.Filters
{
    //public class MyAttribute : TypeFilterAttribute
    //{
    //    public MyAttribute(params string[] Arguments) : base(typeof(TypeFilterAttribute_TimerElasped))
    //    {
    //       this.Arguments = new object[] { Arguments };
    //    }

        public class TypeFilterAttribute_TimerElasped : IActionFilter
        {
            public Stopwatch timer;
            private ILogger logger;
         //   public string[] _arguments { get; set; }

        private readonly string _value;
       // private readonly ILogger<LogConstantFilter> _logger;

        public TypeFilterAttribute_TimerElasped(string value, ILoggerFactory loggerFactory)
            {
            _value = value;
                logger = loggerFactory.CreateLogger<TimeElasped>();
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
    //}
}
