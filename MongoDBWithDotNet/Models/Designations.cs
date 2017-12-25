using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDBWithDotNet.Models
{
    public class Designations
    {
        [BsonId]
        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }
}