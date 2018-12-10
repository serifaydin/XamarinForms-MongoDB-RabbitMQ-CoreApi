using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MLTP.Infrastructure.MongoDB
{
    public class AppModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

    }
}