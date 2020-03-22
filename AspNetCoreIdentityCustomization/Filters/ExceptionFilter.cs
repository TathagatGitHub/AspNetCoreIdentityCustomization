using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


namespace AspNetCoreIdentityCustomization.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionFilter(
            IWebHostEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            if (_hostingEnvironment.IsDevelopment())
            {
                return;
            }


            var result = new ViewResult { ViewName = "ExceptionFilter" };
            if (context.Exception is NotImplementedException)
            {
                result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
                                                         context.ModelState);
                result.ViewData.Add("Exception", context.Exception);
                result.ViewData.Add("ExceptionType", context.Exception.GetType());
              //  result.TempData["Exception"] = context.Exception;

            }
            else
            {
                result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
                                                    context.ModelState);
                result.ViewData.Add("Exception", context.Exception);

            }

            // TODO: Pass additional detailed data via ViewData
            
            context.Result = result;
            
            //return result;

        }
    }
}
