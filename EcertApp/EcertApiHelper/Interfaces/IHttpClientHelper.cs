using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EcertApp.EcertApiHelper.Interfaces
{
   public interface IHttpClientHelper
    {
        HttpClient HttpClient();
    }
}
