using HybridWaiterDataLayer.Models;
using HybridWaiterServiceLayer.DTO;
using HybridWaiterServiceLayer.Services;
using Microsoft.AspNetCore.Mvc;


namespace HybridWaiterAPI.Controllers
{
    [ApiController]
    [Route("Booking")]
    public class BookingController : BaseController<BOOKING, Booking>
    {
        IBookingService service;
        public BookingController(IBookingService bookingService) : base(bookingService)
        {
            service = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            await service.CreateBooking(booking);
            return Ok(true);
        }
    }
}
