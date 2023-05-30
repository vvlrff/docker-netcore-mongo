using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace dockerForum.Models
{
    [BsonIgnoreExtraElements]
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("head")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("text")]
        public string Text { get; set; } = String.Empty;

        [BsonElement("owner")]
        public string Owner { get; set; } = String.Empty;

        [BsonElement("сreated")]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
