using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Financ.API.Services.Log
{
    [BsonIgnoreExtraElements]
    public class ActionLog
    {
        public ActionLog()
        {
            Date = DateTime.Now;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("success"), JsonPropertyName("success")]
        public bool Success { get; set; }
        [BsonElement("description"), JsonPropertyName("description")]
        public string Description { get; set; }
        [BsonElement("date"), JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [BsonElement("userLog"), JsonPropertyName("userLog")]
        public UserLog UserLog { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class UserLog
    {
        [BsonElement("idUser"), JsonPropertyName("idUser")]
        public string IdUser { get; set; }
        [BsonElement("name"), JsonPropertyName("name")]
        public string Name { get; set; }
        [BsonElement("email"), JsonPropertyName("email")]
        public string Email { get; set; }
        [BsonElement("phone"), JsonPropertyName("phone")]
        public string Phone { get; set; }
    }

}
