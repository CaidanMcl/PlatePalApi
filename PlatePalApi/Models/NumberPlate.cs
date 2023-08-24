using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PlatePalApi.Models
{
    public class NumberPlate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [BsonElement("numberPlate")]
        public string numberPlate { get; set; } = null!;

        [BsonElement("AccessStatus")]
        public string AccessStatus { get; set; } = null!;

    }
}
   