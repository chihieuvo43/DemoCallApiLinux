using System.Net.Http;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace WebApp.Helper
{
    public class HocVienApi
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress=new System.Uri("http://localhost:5050/");
            return client;
        }
    }
}