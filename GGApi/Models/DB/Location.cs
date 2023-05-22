using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GGApi.Models.DB
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        [BsonElement("y_coordinate")]
        public decimal Latitude { get; set; }

        [BsonElement("x_coordinate")]
        public decimal Longitude { get; set; }
    }
}
