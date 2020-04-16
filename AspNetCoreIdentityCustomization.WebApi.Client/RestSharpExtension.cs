using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreIdentityCustomization.WebApi.Client
{
  
        public static class RestSharpExtension
        {
            public static Task<IRestResponse> ExecuteTaskAsync(this RestClient @this, RestRequest request)
            {
                if (@this == null)
                    throw new NullReferenceException();

                var tcs = new TaskCompletionSource<IRestResponse>();

                @this.ExecuteAsync(request, (response) =>
                {
                    if (response.ErrorException != null)
                        tcs.TrySetException(response.ErrorException);
                    else
                        tcs.TrySetResult(response);
                });

                return tcs.Task;
            }
        }
    
}
