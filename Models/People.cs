using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace contact_api.Models
{
    public class People
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; } = null;

        [BsonElement("Email")]
        public string? Email { get; set; } = null;

        [BsonElement("Telefone")]
        public string? Telefone { get; set; } = null;

        [BsonElement("Celular")]
        public string? Celular { get; set; } = null;

    }
}
