using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Helper;
using WebApp.Models;
using Newtonsoft.Json.Linq;
//using static IdentityModel.OidcConstants;


namespace WebApp.Controllers
{

    public class HocVienController:Controller
    {
        HocVienApi hocVienApi=new HocVienApi();
        public async Task<IActionResult> Index()
        {
            //client.SetBearerToken(TokenResponse.AccessToken);
            List<HocViens> HocVien=new List<HocViens>();
            HttpClient client=hocVienApi.Initial();
            
           
            HttpResponseMessage res=await client.GetAsync("api/HocVien/");
            
            if(res.IsSuccessStatusCode)
            {
                var result=res.Content.ReadAsStringAsync().Result;
                HocVien=JsonConvert.DeserializeObject<List<HocViens>>(result);
                return View(HocVien);

            }
            return BadRequest();
            // var tokenClient = new TokenClient("http://localhost:5001");
            // var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api.sample");

            // var client = new HttpClient();
            // client.SetBearerToken(tokenResponse.AccessToken);
            // var content = await client.GetStringAsync("http://localhost:5001/api/HocVien/");

            // ViewBag.Json = JArray.Parse(content).ToString();
            // return View("json");
        }
    }
}