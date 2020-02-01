using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Microsoft.Extensions.Logging;
namespace AspNetCoreIdentityCustomization.WebApi.Client
{


    public class RestSharpWebApiClient
    {
        private string _getUrl = "https://prepostlogwebapi.oceanmediainc.com";
        private string _country = "US";
        private string _networktype = "National Cable";
        private string _logType = "Postlog";
        private string _clientId = "fd5ef968-6096-4230-a4dd-7b9ac9eedab0";
        private readonly ILogger _logger;

        public RestSharpWebApiClient(ILogger logger, string APIUrl,string Country,string NetworkType, string Postlog,string ClientId)
        {
            _getUrl= APIUrl;
            _country = Country;
            _networktype = NetworkType;
            _logType = Postlog;
            _clientId = ClientId;
            _logger = logger;
        }

        public RestSharpWebApiClient(ILogger logger, string APIUrl)
        {
            _getUrl = APIUrl;
            _logger = logger;

        }
        public async void  RestClientGetMethod()
        {
            _logger.LogInformation("Inside the RestClientMethod!");
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.POST);
           //restClient.BaseUrl = System.Uri(_getUrl);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientKey", _clientId);

            //restRequest.AddParameter("country", _country, ParameterType.RequestBody);
            //restRequest.AddParameter("networktype", _networktype, ParameterType.RequestBody);

            //restRequest.AddParameter("LogType", _logType, ParameterType.RequestBody);

            var cancellationTokenSource = new CancellationTokenSource();
            //string jsonBody = "{"+
            //                    "\"country\":\"US\","+
            //                    "\"networktype\":\"National Cable\","+
            //                    "\"LogType\":\"Postlog\"  }";
            string jsonBody1 = "{" +
                                "\"country\":\"US\"," +
                                "\"networktype\":\"National Cable\"," +
                                "\"LogType\":\"Prelog\"}";

            restRequest.AddJsonBody(jsonBody1);
            restClient.ExecuteAsync(restRequest, response =>
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.ContentLength);
                Console.WriteLine(response.Content);
                _logger.LogInformation("StatusCode:" + response.StatusCode);
                _logger.LogInformation("ContentLength:" + response.ContentLength);
                _logger.LogInformation("Content:" + response.Content);
            });

           // Will output the HTML contents of the requested page
            //return restResponse;
        }


        public async void RestClientGAReportPostMethod()
        {
            _logger.LogInformation("Inside the RestClientGAReportPostMethod!");
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.GET);
            //restClient.BaseUrl = System.Uri(_getUrl);

            restRequest.AddHeader("Content-Type", "application/json");
          

            var cancellationTokenSource = new CancellationTokenSource();
         
            restClient.ExecuteAsync(restRequest, response =>
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.ContentLength);
                Console.WriteLine(response.Content);
                _logger.LogInformation("StatusCode:" + response.StatusCode);
                _logger.LogInformation("ContentLength:" + response.ContentLength);
                _logger.LogInformation("Content:" + response.Content);
            });

            // Will output the HTML contents of the requested page
            //return restResponse;
        }
    }

    
}
