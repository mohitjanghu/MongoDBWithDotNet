using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBWithDotNet.Models
{
    public class Employee
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }

    }
}