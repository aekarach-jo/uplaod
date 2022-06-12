using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImageSaveAndReadCoreMongoDB.Models
{
    public class Employee
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public byte[] Photo { get; set; }
    }
}
