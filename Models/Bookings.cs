using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoAssessment.Models
{
    public class Bookings
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public object? Id { get; set; }
        [BsonElement("booking_id")]
        [BsonRepresentation(BsonType.Int32)]
        public int BookingId { get; set; }
        [BsonElement("start_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Startdate { get; set; }
        [BsonElement("end_date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime EndDate { get; set; }
    }
}
