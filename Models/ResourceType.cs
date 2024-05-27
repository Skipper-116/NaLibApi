using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class ResourceType
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; }

    [BsonElement("description")]
    public string Description { get; set; }

    [BsonElement("createdBy")]
    public int CreatedBy { get; set; }

    [BsonElement("updatedBy")]
    public int UpdatedBy { get; set; }

    [BsonElement("voided")]
    public bool Voided { get; set; }

    [BsonElement("voidedBy")]
    public int VoidedBy { get; set; }

    [BsonElement("voidedOn")]
    public DateTime VoidedOn { get; set; }

    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

    [BsonElement("updatedAt")]
    public DateTime UpdatedAt { get; set; }

    //lend out limit
    [BsonElement("lendOutLimit")]
    public int LendOutLimit { get; set; }

    // Add more properties as needed

    // Optional: Define any additional constructors or methods
}
