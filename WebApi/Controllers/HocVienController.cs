using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HocVienController : ControllerBase
    {
        private readonly HocVienService _hocVienService;
        public HocVienController(HocVienService hocVienService)
        {
            _hocVienService=hocVienService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<HocViens>> Get()
        {
            return _hocVienService.Get();
        }
        [HttpGet(Name="GetHocVien")]
        public ActionResult<HocViens> Get(string Id)
        {
            return _hocVienService.Get(Id);
        }
        [HttpPost]
        public ActionResult<HocViens> Post(HocViens HocVien)
        {
            _hocVienService.Create(HocVien);
            return CreatedAtRoute("GetHocVien",new {Id=HocVien.Id.ToString()},HocVien);
        }

       
    }
}
