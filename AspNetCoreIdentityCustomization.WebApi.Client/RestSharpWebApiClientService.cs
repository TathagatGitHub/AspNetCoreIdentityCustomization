using AspNetCoreIdentityCustomization.Core;
using AspNetCoreIdentityCustomization.Data;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{
    public class RestSharpWebApiClientService : IRestSharpWebApiClientService
    {
        //private string _getUrl = "https://prepostlogwebapi.oceanmediainc.com";
        //private string _country = "US";
        //private string _networktype = "National Cable";
        //private string _logType = "Postlog";
        //private string _clientId = "fd5ef968-6096-4230-a4dd-7b9ac9eedab0";
        private PostLogLineRepository _postlogLinerepository;
        //private readonly ILogger _logger;
        private readonly ILogger<RestSharpWebApiClientService> _logger;
        public RestSharpWebApiClientService(ILogger <RestSharpWebApiClientService> logger, PostLogLineRepository postlogLinerepository)
        {            
            _logger = logger;
            _postlogLinerepository = postlogLinerepository;
        }
        public async Task<SearchResponse> GetUsingRestSharpAndBulkInsertUsingDapper(string ClientKey,String RequestBody,
            string RequestURL)
        {

            _logger.LogInformation("Inside the Pre-postlog Controler Method!");
            var searchResponse = new SearchResponse();
            IRestClient restClient = new RestClient(RequestURL); //"https://prepostlogwebapi.oceanmediainc.com";
            IRestRequest restRequest = new RestRequest(Method.POST);

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("ClientKey", ClientKey); // "fd5ef968-6096-4230-a4dd-7b9ac9eedab0";

            restRequest.AddJsonBody(RequestBody);
            //"{" +
            //                   "\"country\":\"US\"," +
            //                   "\"networktype\":\"National Cable\"," +
            //                   "\"LogType\":\"Prelog\"}";
            TaskCompletionSource<IRestResponse> taskCompletion = new TaskCompletionSource<IRestResponse>();
            restClient.ExecuteAsync<SearchResponse>(restRequest, r => taskCompletion.SetResult(r));
            IRestResponse response = default(IRestResponse);

            response = (IRestResponse)(await taskCompletion.Task);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                searchResponse = JsonSerializer.Deserialize<SearchResponse>(response.Content);
                //var dataTable = response.Schema.Fields.AsDataTable(searchResponse);
                _postlogLinerepository.InsertBulkPostLogLineAsync(searchResponse.Data);
            }
            else
                searchResponse.ErrorResult.ErrorDescription = response.ErrorMessage;

            // Will output the HTML contents of the requested page
            return searchResponse;
        }
    }
}
