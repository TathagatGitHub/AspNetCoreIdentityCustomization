using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{

    
    public class RestSharpWebApiClient
    {
        private string getUrl = "https://prepostlogwebapi.oceanmediainc.com";

        public async void  RestClientGetMethod()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl,Method.GET);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientID", "b4d153b5-960a-42f8-9397-a893b343a983");

            restRequest.AddParameter("country", "US", ParameterType.RequestBody);
            restRequest.AddParameter("networktype", "National Cable", ParameterType.RequestBody);

            restRequest.AddParameter("LogType", "Postlog", ParameterType.RequestBody);

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
