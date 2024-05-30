using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NaLibApi.Models
{
    [BsonIgnoreExtraElements]
    public class ResourceType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }

        [BsonElement("name")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonElement("description")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonElement("createdBy")]
        [BsonRequired]
        [BsonRepresentation(BsonType.Int32)]
        [JsonIgnore]
        public int CreatedBy { get; set; }

        [BsonElement("updatedBy")]
        [BsonRepresentation(BsonType.Int32)]
        [JsonIgnore]
        public int? UpdatedBy { get; set; }

        [BsonElement("voided")]
        [JsonIgnore]
        public bool Voided { get; set; }

        [BsonElement("voidedBy")]
        [BsonRepresentation(BsonType.Int32)]
        [JsonIgnore]
        public int? VoidedBy { get; set; }

        [BsonElement("voidedOn")]
        [BsonRepresentation(BsonType.DateTime)]
        [JsonIgnore]
        public DateTime VoidedOn { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        //lend out limit
        [BsonElement("lendOutLimit")]
        [BsonRepresentation(BsonType.Int32)]
        public int LendOutLimit { get; set; }
    }
}
