using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreIdentityCustomization.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        [Route ("Error")]
        public IActionResult Error()
        {
            var _exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.ExceptionPath = _exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = _exceptionHandlerPathFeature.Error.Message;
            ViewBag.ExceptionStackTrace = _exceptionHandlerPathFeature.Error.StackTrace;
            return View();
        }
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry the page you requested could not be found";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry something went wrong on the server";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
            }

            return View();
        }
    }
}