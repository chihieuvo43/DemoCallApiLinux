using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Helper;
using WebApp.Models;

namespace WebApp.Controllers
{

    public class HocVienController:Controller
    {
        HocVienApi hocVienApi=new HocVienApi();
        public async Task<IActionResult> Index()
        {
            List<HocViens> HocVien=new List<HocViens>();
            HttpClient client=hocVienApi.Initial();
            HttpResponseMessage res=await client.GetAsync("api/HocVien");
            if(res.IsSuccessStatusCode)
            {
                var result=res.Content.ReadAsStringAsync().Result;
                HocVien=JsonConvert.DeserializeObject<List<HocViens>>(result);

            }
            return View(HocVien);
        }
    }
}