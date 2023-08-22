using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MongoAssessment.Models;
using MongoAssessment.Services;
using MongoDB.Bson;

namespace MongoAssessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService _bookingService;
        private readonly ILogger<BookingsController> _logger;

        public BookingsController(ILogger<BookingsController> logger, BookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        [HttpGet(Name = "GetBoookings")]
        [EnableCors("AllowOrigin")]
        public async Task<List<Bookings>> Get()
        {
            return await _bookingService.GetAsync();
        }
    }
}