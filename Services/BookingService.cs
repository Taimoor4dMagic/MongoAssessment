using Microsoft.Extensions.Options;
using MongoAssessment.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoAssessment.Services
{
    public class BookingService
    {
        private readonly IMongoCollection<BsonDocument> _bookingCollection;

        public BookingService(
            IOptions<MBOTDatabaseSetting> mbotDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                mbotDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                mbotDatabaseSettings.Value.DatabaseName);

            _bookingCollection = mongoDatabase.GetCollection<BsonDocument>(
                mbotDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Bookings>> GetAsync()
        {
            List<Bookings> bookings = new List<Bookings>();
            var projection = Builders<BsonDocument>.Projection
                .Include("booking_id")
                .Include("start_date")
                .Include("end_date")
                .Include("_id");
            var result = await _bookingCollection.Find(FilterDefinition<BsonDocument>.Empty).Project(projection).ToListAsync();
            foreach (var doc in result)
            {
                var booking = new Bookings
                {
                    Id = doc["_id"].AsObjectId,
                    Startdate = (DateTime)doc["start_date"].AsBsonDateTime,
                    EndDate = (DateTime)doc["start_date"].AsBsonDateTime,
                    BookingId = doc["booking_id"].AsInt32,
                };
                bookings.Add(booking);
            }
            return bookings;
        }
    }
}
