using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace cd_plantilla_backend.Models
{
    public class Template
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; } = String.Empty;

        [BsonElement("createdBy")]
        public string CreatedBy { get; set; } = string.Empty;

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    }
}
