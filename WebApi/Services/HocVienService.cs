using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using WebApi.Models;

namespace WebApi.Services
{
    public class HocVienService
    {
        private readonly IMongoCollection<HocViens> _hocViens;
        public HocVienService(IConfiguration Config)
        {
            var client=new MongoClient(Config.GetConnectionString("MongoDB"));
            var database=client.GetDatabase("DemoCallApi");
            _hocViens=database.GetCollection<HocViens>("HocViens");
        }
        public List<HocViens> Get()
        {
            return _hocViens.Find(HocVien=>true).ToList();
        }

        public HocViens Get(string Id)
        {
            return _hocViens.Find<HocViens>(HocVien=>HocVien.Id==Id).FirstOrDefault();
        }
        public HocViens Create(HocViens HocVien)
        {
            _hocViens.InsertOne(HocVien);
            return HocVien;
        }
    }
}