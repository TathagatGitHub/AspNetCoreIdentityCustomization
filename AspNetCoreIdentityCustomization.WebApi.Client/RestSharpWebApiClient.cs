using System;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Microsoft.Extensions.Logging;
using RESPApiProject.Controllers;

using System.Collections.Generic;
using RESPApiProject;
using AspNetCoreIdentityCustomization.Core;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
//using AspNetCoreIdentityCustomization.WebApi.Client;
using System.Net.Http;
using System.Net;
using AspNetCoreIdentityCustomization.Data;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{
    public class RestSharpWebApiClient
    {
        //private PostLogLineRepository _postlogLinerepository;
        private string _getUrl = "https://prepostlogwebapi.oceanmediainc.com";
        private string _country = "US";
        private string _networktype = "National Cable";
        private string _logType = "Postlog";
        private string _clientId = "fd5ef968-6096-4230-a4dd-7b9ac9eedab0";
        private readonly ILogger _logger;

        public RestSharpWebApiClient(ILogger logger, string APIUrl,string Country,
            string NetworkType, string Postlog,string ClientId)//, WeatherForecastController weatherForecastController )
        {
            _getUrl= APIUrl;
            _country = Country;
            _networktype = NetworkType;
            _logType = Postlog;
            _clientId = ClientId;
            _logger = logger;
            //_postlogLinerepository = postlogLinerepository;
            //_weatherForecastController = weatherForecastController;
        }

        public RestSharpWebApiClient(ILogger logger, string APIUrl)
        {
            _getUrl = APIUrl;
            _logger = logger;
        }

        //RestSharp Client, wrting response to log
        public async Task<ActionResult<SearchResponse>> RestClientGetMethodAsync()
          {
            _logger.LogInformation("Inside the Pre-postlog Controler Method!");
            var searchResponse = new SearchResponse();
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.POST);
         
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientKey", _clientId);

            
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
           //    _logger.LogInformation("Content:" + response.Content);
               // searchResponse.SearchResults = response.Content;
                searchResponse.Data =  JsonSerializer.Deserialize<IList<PostLogLine>>(response.Content);
            });

           // Will output the HTML contents of the requested page
           return  searchResponse;
        }

        public async Task<SearchResponse> RestSharpClientGetMethodAsync()
        {

            string jsonBody1 = "{" +
                               "\"country\":\"US\"," +
                               "\"networktype\":\"National Cable\"," +
                               "\"LogType\":\"Prelog\"}";


            _logger.LogInformation("Inside the Pre-postlog Controler Method!");
            var searchResponse = new SearchResponse();
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.POST);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientKey", _clientId);

            restRequest.AddJsonBody(jsonBody1);
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            restClient.ExecuteAsync<SearchResponse>(restRequest, r => taskCompletion.SetResult(r));
            IRestResponse response = default(IRestResponse);

            response = (IRestResponse)(await taskCompletion.Task);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                searchResponse = JsonSerializer.Deserialize<SearchResponse>(response.Content);
                //var dataTable = response.Schema.Fields.AsDataTable(searchResponse);
                // _postlogLinerepository.InsertBulkPostLogLineAsync(searchResponse.Data);
            }
            else
                searchResponse.ErrorResult.ErrorDescription = response.ErrorMessage;

            // Will output the HTML contents of the requested page
            return searchResponse;
        }
       // GAReport Client
        public async void RestClientGAReportPostMethod()
        {
            _logger.LogInformation("Inside the RestClientGAReportPostMethod!");
            IRestClient restClient = new RestClient(_getUrl);
            IRestRequest restRequest = new RestRequest(Method.GET);
            //restClient.BaseUrl = System.Uri(_getUrl);

            restRequest.AddHeader("Content-Type", "application/json");

            restRequest.AddParameter("CallingMethod", "RestSharp API Client Localhost", ParameterType.RequestBody);
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

        //Syncronus call - Works! 
        public async Task<SearchResponse> HttpClientPrePostLogMethod()
        {
            var values = new Dictionary<string, string>
            {
                {"country","US" },
                {"networktype","National Cable"},
                {"LogType","Postlog" }

            };
            List<PostLogLine> postloglist = new List<PostLogLine>();
            var searchResponse = new SearchResponse();
         
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, _getUrl);

                requestMessage.Headers.Add("ClientKey", _clientId);

               httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
          
               requestMessage.Content = new FormUrlEncodedContent(values);

                // Send the request to the server
                HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

                // Just as an example I'm turning the response into a string here
                string responseAsString = await response.Content.ReadAsStringAsync();

                //     var responseStream = await response.Content.ReadAsStringAsync();
                //searchResponse.SearchResults = JsonSerializer.Deserialize<IList<PostLogLine>>(responseAsString);
                searchResponse = JsonSerializer.Deserialize<SearchResponse>(response.Content.ReadAsStringAsync().Result);
            }
            return searchResponse;
        }

        //public async Task<SearchResponse> GetPrePostLogLineDataAsync(string prepostServiceUrl, string apiKey, RequestBodyModel requestModel)
        //{
        //    var response = new SearchResponse() { Data = new List<PostLogLine>() };
        //    var dataAsString = Newtonsoft.Json.JsonConvert.SerializeObject(requestModel);
        //    var content = new StringContent(dataAsString);
        //    using (var client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Add("ClientKey", apiKey);
        //        client.BaseAddress = new Uri(prepostServiceUrl);
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //        client.Timeout = TimeSpan.FromMinutes(60);
        //     var responseObj = await client.PostAsync(prepostServiceUrl, content);
        //        //var responseObj = client.PostAsJsonAsync(prepostServiceUrl, content).Result;
        //         if (responseObj != null)
        //        {
        //            if (responseObj.StatusCode.Equals(HttpStatusCode.OK))
        //            {
        //                response = Newtonsoft.Json.JsonConvert.DeserializeObject<SearchResponse>(responseObj.Content.ReadAsStringAsync().Result);
        //            }
        //            else
        //            {
        //                response.ErrorResult.ErrorDescription = responseObj.Content.ReadAsStringAsync().Result;
        //                response.ErrorResult.ErrorCode = 99;
        //            }
        //        }
        //        return response;
        //    }
        //}
    }

    
}
