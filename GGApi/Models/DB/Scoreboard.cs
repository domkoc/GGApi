using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GGApi.Models.DTOs;

namespace GGApi.Models.DB
{
    public class Scoreboard
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Username { get; set; }

        public int Score { get; set; }
    }
}
