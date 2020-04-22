using AspNetCoreIdentityCustomization.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{
    public interface IRestSharpWebApiClientService
    {
        public Task<SearchResponse> GetUsingRestSharpAndBulkInsertUsingDapper(string ClientKey, String RequestBody,
            string RequestURL);
    }
}
