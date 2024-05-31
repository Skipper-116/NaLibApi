using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace NaLibApi.Models
{
    public class Catalog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault]
        public string? Id { get; set; }
        [BsonElement("title")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Title { get; set; }
        [BsonElement("authors")]
        [BsonRequired]
        public List<string> Authors { get; set; }
        [BsonElement("publisher")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Publisher { get; set; }
        [BsonElement("isbn")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string ISBN { get; set; }
        [BsonElement("publicationDate")]
        [BsonRequired]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime PublicationDate { get; set; }
        [BsonElement("subjects")]
        [BsonRequired]
        public List<string> Subjects { get; set; }
        [BsonElement("genres")]
        [BsonRequired]
        public List<string> Genres { get; set; }
        [BsonElement("language")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string Language { get; set; }
        [BsonElement("keywords")]
        [BsonRequired]
        public List<string> Keywords { get; set; }
        [BsonElement("classificationNumber")]
        [BsonRequired]
        [BsonRepresentation(BsonType.String)]
        public string ClassificationNumber { get; set; }
        [BsonElement("description")]
        [BsonRequired]
        public PhysicalDescription Description { get; set; }
        [BsonElement("history")]
        [BsonRequired]
        public PublicationHistory[] History { get; set; }
        [BsonElement("seriesInfo")]
        [BsonRequired]
        public Series SeriesInfo { get; set; }
        [BsonElement("holdings")]
        [BsonRequired]
        public List<Holding> Holdings { get; set; }
        [BsonElement("reviews")]
        [BsonRequired]
        public List<Review> Reviews { get; set; }
        [BsonElement("tableOfContents")]
        [BsonRequired]
        public List<Content> TableOfContents { get; set; }
        [BsonElement("libraryId")]
        [BsonRequired]
        [BsonRepresentation(BsonType.Int32)]
        public int LibraryId { get; set; }
        [BsonElement("resourceTypeId")]
        [BsonRequired]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ResourceTypeId { get; set; }
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
        [BsonRepresentation(BsonType.Boolean)]
        [BsonDefaultValue(false)]
        [JsonIgnore]
        public bool Voided { get; set; }
        [BsonElement("voidedBy")]
        [BsonRepresentation(BsonType.Int32)]
        [JsonIgnore]
        public int? VoidedBy { get; set; }
        [BsonElement("voidedOn")]
        [BsonRepresentation(BsonType.DateTime)]
        [JsonIgnore]
        public DateTime? VoidedOn { get; set; }
    }
}
