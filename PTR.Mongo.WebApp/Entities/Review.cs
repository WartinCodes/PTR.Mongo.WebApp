using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PTR.Mongo.WebApp.Entities
{
    public class Review
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("productId")]
        public string ProductId { get; set; }

        [BsonElement("authorName")]
        public string AuthorName { get; set; } = "Anonymous";

        [BsonElement("comment")]
        public string Comment { get; set; }

        [BsonElement("rating")]
        public int Rating { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
