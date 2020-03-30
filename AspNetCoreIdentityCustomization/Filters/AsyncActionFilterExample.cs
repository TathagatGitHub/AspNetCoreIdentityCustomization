using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.Filters
{
    public class AsyncActionFilterExample : IAsyncActionFilter
    {
        public Stopwatch timer;
        private ILogger logger;
        private readonly string _value;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
            // Do something before the action executes.
            timer = Stopwatch.StartNew();
            // next() calls the action method.
            var resultContext = await next();
            timer.Stop();
            // resultContext.Result is set.
            // Do something after the action executes.
        }
        
    }
}
