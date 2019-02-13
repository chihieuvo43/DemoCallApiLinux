using System.Net.Http;

namespace WebApp.Helper
{
    public class HocVienApi
    {
        public HttpClient Initial()
        {
            var client=new HttpClient();
            client.BaseAddress=new System.Uri("http://localhost:47399");
            return client;
        }
    }
}