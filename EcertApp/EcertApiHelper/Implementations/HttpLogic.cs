using EcertApp.Dto;
using EcertApp.EcertApiHelper.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EcertApp.EcertApiHelper.Implementations
{
    public class HttpLogic <T> : IHttpLogic<T>
    {
        private readonly IHttpClientHelper _http;
        public HttpLogic(IHttpClientHelper http)
        {
            _http = http;
        }

        public async Task<string> Delete(string url)
        {
            var httpClient = _http.HttpClient();
            var response = await httpClient.DeleteAsync(url);
            return response.StatusCode.ToString();
        }

        public async Task<IEnumerable<T>> Get(string url)
        {
            var httpClient = _http.HttpClient();
            var response = await httpClient.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<T>>(responseContent);
            return data;
        }

        public async Task<T> GetbyId(int id, string url)
        {
            var httpClient = _http.HttpClient();
            var response = await httpClient.GetAsync(url+id);
            if (response.StatusCode==System.Net.HttpStatusCode.OK)
            {
             var responseContent= await response.Content.ReadAsStringAsync();

             var data = JsonConvert.DeserializeObject<T>(responseContent);

                return  data;
            }

            throw new NotImplementedException();
        }

        public async Task<string> PostCall(T Entity, string url)
        {
            var httpClient = _http.HttpClient();
            var jsonData = JsonConvert.SerializeObject(Entity);
            var data = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, data);
            return response.StatusCode.ToString();
        }

    }
}
