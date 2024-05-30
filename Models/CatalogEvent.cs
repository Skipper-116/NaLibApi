using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace NaLibApi.Models
{
    public class CatalogEvent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
        [BsonElement("eventType")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string EventType { get; set; }
        [BsonElement("catalogId")]
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        // reference to the catalog
        public string CatalogId { get; set; }

        // json property named changes for tracking changes
        [BsonElement("changes")]
        [BsonRequired]
        [BsonRepresentation(BsonType.Array)]
        public List<Catalog> Changes { get; set; }

        // timestamp for when the event was created
        [BsonElement("createdAt")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime CreatedAt { get; set; }
        [BsonElement("updatedAt")]
        [BsonRepresentation(BsonType.DateTime)]
        [BsonRequired]
        public DateTime UpdatedAt { get; set; }
    }
}