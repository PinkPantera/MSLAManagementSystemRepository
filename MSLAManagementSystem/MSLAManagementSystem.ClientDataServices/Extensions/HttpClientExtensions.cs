using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public static async Task<IList<T>> GetAsync<T>(this HttpClient httpClient, string requestUri)
        {
            IList<T> list;
            using (var reponce = await httpClient.GetAsync(requestUri))
            {
                var apiReponce = await reponce.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<T>>(apiReponce);
            }

            return list;
        }

        public static async Task<T> PutAsync<T>(this HttpClient httpClient, string requestUri, T putData)
        {
            var personString = JsonConvert.SerializeObject(putData);
            var contentData = new StringContent(personString, System.Text.Encoding.UTF8, "application/json");
            var reponse = await httpClient.PutAsync(requestUri, contentData);
            var result = reponse.IsSuccessStatusCode;

            if (!result)
            {
                var errorsStr = await reponse.Content.ReadAsStringAsync();

                throw new Exception($"Can't update person: \n {errorsStr}");
            }

            var resultStr = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultStr);
        }

        public static async Task <T> PostAsync<T>(this HttpClient httpClient, string requestUri, T postData)
        {
            var personString = JsonConvert.SerializeObject(postData);
            var contentData = new StringContent(personString, System.Text.Encoding.UTF8, "application/json");
            var reponse = await httpClient.PostAsync(requestUri, contentData);
            var result = reponse.IsSuccessStatusCode;

            if (!result)
            {
                var errorsStr = await reponse.Content.ReadAsStringAsync();

                throw new Exception($"Can't creat person: \n {errorsStr}");
            }

            var resultStr = await reponse.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(resultStr);
        }
    }
}
