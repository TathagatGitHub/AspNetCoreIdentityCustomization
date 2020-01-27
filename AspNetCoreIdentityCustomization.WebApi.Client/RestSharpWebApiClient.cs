using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{


    public class RestSharpWebApiClient
    {
        private string _getUrl = "https://prepostlogwebapi.oceanmediainc.com";
        private string _country = "US";
        private string _networktype = "National Cable";
        private string _logType = "Postlog";
        private string _clientId = "b4d153b5-960a-42f8-9397-a893b343a983";

    
        public RestSharpWebApiClient(string APIUrl,string Country,string NetworkType, string Postlog,string ClientId)
        {
            _getUrl= APIUrl;
            _country = Country;
            _networktype = NetworkType;
            _logType = Postlog;
            _clientId = ClientId;
        }
        public async void  RestClientGetMethod()
        {
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.POST);
           //restClient.BaseUrl = System.Uri(_getUrl);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientID", _clientId);

            restRequest.AddParameter("country", _country, ParameterType.RequestBody);
            restRequest.AddParameter("networktype", _networktype, ParameterType.RequestBody);

            restRequest.AddParameter("LogType", _logType, ParameterType.RequestBody);

            var cancellationTokenSource = new CancellationTokenSource();

            restClient.ExecuteAsync(restRequest, response =>
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.ContentLength);
                Console.WriteLine(response.Content);
            });

           // Will output the HTML contents of the requested page
            //return restResponse;
        }
    }

    
}
