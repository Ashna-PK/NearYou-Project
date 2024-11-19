using Booking.Api.Models;
using Booking.Api.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _context;

        public BookingController(IBookingRepository context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetOrders()
        {
            var result = await _context.getOrders();
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bookings>> GetOrderById(int id)
        {
            var order = await _context.getOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetOrderByUserId(int id)
        {
            var order = await _context.getOrdersByUserId(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        [HttpGet("shop/{id}")]
        public async Task<ActionResult<IEnumerable<Bookings>>> GetOrderByShopId(int id)
        {
            var order = await _context.getOrdersByShopId(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPost]
        public async Task<ActionResult<Bookings>> PostBooking(Bookings booking)
        {
            var result = await _context.createOrder(booking);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _context.deleteOrder(id);
            if (!result)/// result==null (dont do)
                return NotFound("order not found.");
            return Ok(result);
        }
    }
}
