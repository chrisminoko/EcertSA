using EcertApp.EcertApiHelper.Interfaces;
using System.Net.Http;

namespace EcertApp.EcertApiHelper.Implementations
{
    public class HttpClientHelper : IHttpClientHelper
    {
        public HttpClient HttpClient()
        {
            return new HttpClient();
        }
    }
}
