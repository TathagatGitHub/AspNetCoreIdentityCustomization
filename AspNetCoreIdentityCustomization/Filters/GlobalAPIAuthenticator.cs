using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace AspNetCoreIdentityCustomization.Filters
{

    public class GlobalAPIAuthenticator 
    {
		private RequestDelegate next;
        private const string ApiKeyHeaderName = "ApiKey";

        private string ClientName = "ClientName";

        private readonly IConfiguration _config;

        public GlobalAPIAuthenticator(RequestDelegate next)
		{
			this.next = next;
            //this._config = configuration;


        }

       
           
        public async Task Invoke(HttpContext context, IConfiguration configuration)
        {
           //Following two lines are to get thr Route Data/path from the request and take any decision, as per the Rooute Path, if needed.- Starts
            var httpRequestFeature = context.Features[typeof(IHttpRequestFeature)] as IHttpRequestFeature;
            var path = httpRequestFeature?.Path;
            //Following two lines are to get thr Route Data/path from the request and take any decision, as per the Rooute Path, if needed.- Ends
            var requestHeaders = context.Request.Headers;
            if (!requestHeaders.ContainsKey(ApiKeyHeaderName))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Client Key does not found in request headers");
                return;
            }
          //  Guid customerGuidKey;
            var clientKey = requestHeaders[ApiKeyHeaderName];
            if (string.IsNullOrWhiteSpace(clientKey))
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsync("Invalid Client Key found in request headers");
                return;
            }
            try
            {
              //  var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                var apiKey = configuration.GetValue<string>(ApiKeyHeaderName);
               // Guid.TryParse(clientKey, out customerGuidKey);
                if (!apiKey.Equals(clientKey))
                {
                    await context.Response.WriteAsync("Invalid Client Key. No Customer listed with the Client Key in Request headers");
                    return;
                }

                //DataProviderAPIAccount custAccDetails = default(DataProviderAPIAccount);
                //Guid.TryParse(clientKey, out customerGuidKey);
                //if (_Platform.Equals(Constants.APIPlatforms.DCPDCM, StringComparison.InvariantCultureIgnoreCase))
                //{
                //    var repository = (DCMApiRepository)context.RequestServices.GetService(typeof(DCMApiRepository));
                //    custAccDetails = repository.GetCustomerDetailsByCustomerKey(customerGuidKey);
                //}
                //else if (_Platform.Equals(Constants.APIPlatforms.DCPTradeDesk, StringComparison.InvariantCultureIgnoreCase))
                //{
                //    var repository = (DCPTradeDeskRepository)context.RequestServices.GetService(typeof(DCPTradeDeskRepository));
                //    custAccDetails = repository.GetCustomerDetailsByCustomerKey(customerGuidKey);
                //}
                //if (custAccDetails == null)
                //{
                //    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                //    await context.Response.WriteAsync("Invalid Client Key. No Customer listed with the Client Key in Request headers");
                //    return;
                //}
                //context.Items["CurrentCustomerDetails"] = custAccDetails;
            }
            catch (Exception ex)
            {
                //if(ex is FormatException) {
                //    context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                //    await context.Response.WriteAsync($"Invalid Client Key. No Customer listed with the Client Key in Request headers");
                //}
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync($"Exception raised while validating the Customer with the Customer Key. Exception Message: {ex.Message}");
                return;
            }
            await next.Invoke(context);
        }

     

    }
	public static class GlobalAPIAuthExtensionHandler
	{
		public static IApplicationBuilder UseGlobalAPIAuthenticator(this IApplicationBuilder builder)
		{
            //return builder.UseMiddleware<APIKeyMessageHandler>(Constants.APIPlatforms.DCPDCM);
            // If anaonymus return directly no need to call the handler
            return builder.UseMiddleware<GlobalAPIAuthenticator>();
            //return builder.UseMiddleware<AddAuthorizeFiltersControllerConvention>();
        }
		//public static IApplicationBuilder TradeDeskAuthHandler(this IApplicationBuilder builder) {
		//    return builder.UseMiddleware<APIKeyMessageHandler>(Constants.APIPlatforms.DCPTradeDesk);
		//}
	}


}
