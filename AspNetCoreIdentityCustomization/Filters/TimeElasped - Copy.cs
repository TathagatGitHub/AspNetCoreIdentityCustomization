using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


//namespace AspNetCoreIdentityCustomization.Filters
//{
//    public class TimeElasped-copy : ActionFilterAttribute
//    {
//        private Stopwatch timer;
        
//        private readonly ILogger _logger;

//    //private readonly ILoggerFactory _logger;

//        //public TimeElasped(ILoggerFactory logger)
//        //{
//        //    this._logger = logger;
//        //  //  this._actionName = actionName;
//        //    //this._actionType = actionType;
//        //}

//        public TimeElasped(ILogger logger)
//        {
//            _logger = logger;
//        }
//        public void OnActionExecuting(ActionExecutingContext context)
//        {

//            timer = Stopwatch.StartNew();
//            //var logger = DependencyResolver.Current.GetService<ILoggingService>();

//        }
//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            timer.Stop();
//            string result = " Elapsed time: " + $"{timer.Elapsed.TotalMilliseconds} ms";
//            _logger.LogDebug(result.ToString());
//            // Log(Encoding.UTF8.GetString(data));
//            //IActionResult iActionResult = context.Result;
//            //((ObjectResult)iActionResult).Value += result;
//        }
//    }
//}
