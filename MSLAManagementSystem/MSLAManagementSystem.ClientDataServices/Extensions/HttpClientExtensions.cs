using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MSLAManagementSystem.ClientDataServices.Extensions
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> DeleteByIdAsync(this HttpClient httpClient, string requestUri, int id)
        {
            var requestToDelete = requestUri + "/" + id;
            return httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestToDelete));
        }
    }
}
