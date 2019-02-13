using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApi.Models
{
    public class HocViens
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get;set;}
        public string HoVaTen{get;set;}
        public string Email{get;set;}
        public string SoDienThoai{get;set;}
    }
}