
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoTest2.Data.Entities
{

    public class Note
    {
    //    [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public int UserId { get; set; } = 0;
    }

}