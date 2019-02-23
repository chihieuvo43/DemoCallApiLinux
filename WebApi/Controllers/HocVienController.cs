using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   //[EnableCors("AllowSpecificOrigin")]
    //[Authorize]
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
        [HttpGet("{Id}",Name="GetHocVien")]
        public ActionResult<HocViens> Get(string Id)
        {
            var HocVien=_hocVienService.Get(Id);
            if(HocVien==null)
            {
                return NotFound();
            }
            return HocVien;
        }
        [HttpPost]
        public ActionResult<HocViens> Post(HocViens HocVien)
        {
            _hocVienService.Create(HocVien);
            return CreatedAtRoute("GetHocVien",new {Id=HocVien.Id.ToString()},HocVien);
        }
        [HttpPut("{Id}")]
        public IActionResult Update(string Id,HocViens HocVien)
        {
            var hocVien=_hocVienService.Get(Id);
            if(hocVien==null)
            {
                return NotFound();
            }
            _hocVienService.Update(Id,HocVien);
            return Ok();
        }
        [HttpDelete]
         public ActionResult Delete(HocViens HocVien)
        {
            var hocVien=_hocVienService.Get(HocVien.Id);
            if(hocVien==null)
            {
                return NotFound();
            }
            _hocVienService.Delete(HocVien);
            return Ok();
        }
         [HttpDelete("{Id}")]
         public ActionResult Delete(string Id)
        {
            var hocVien=_hocVienService.Get(Id);
            if(hocVien==null)
            {
                return NotFound();
            }
            _hocVienService.Delete(Id);
            return Ok();
        }
    }
}
