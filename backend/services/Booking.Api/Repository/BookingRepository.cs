using Booking.Api.Data;
using Booking.Api.Models;
using Booking.Api.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Booking.Api.Repository
{
    public class BookingRepository : IBookingRepository
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        public BookingDbContext _context;
        //public BookingItemRepository _item;
        public BookingRepository(BookingDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            //_httpClientFactory = httpClientFactory;
        }
        public async Task<Bookings> createOrder(Bookings booking)
        {
             var book=_context.bookings.Add(booking).Entity;
            await _context.SaveChangesAsync();
 
            return book;
        }

        public async Task<bool> deleteOrder(int id)
        {
            var item = await _context.bookings.FindAsync(id);
            if (item == null)
            {
                return false;
            }
            _context.bookings.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Bookings>> getOrders()
        {
            return await _context.bookings.ToListAsync();
        }
        public async Task<Bookings?> getOrderById(int id)
        {
            var item = await _context.bookings.FindAsync(id);

            if (item == null)
            {
                return new Bookings();
            }

            return item;
        }

        public async Task<List<Bookings>> getOrdersByUserId(int userId)
        {
            var item = await _context.bookings.Where(x => x.Userid == userId).ToListAsync();
            if (item == null)
            {
                return new List<Bookings>();
            }

            return item;
        }
        public async Task<List<Bookings>> getOrdersByShopId(int shopId)
        {
            var item = await _context.bookings.Where(x => x.vendorId == shopId).ToListAsync();
            if (item == null)
            {
                return new List<Bookings>();
            }

            return item;
        }

        //public Task<Bookings> updateOrder(int id, Bookings booking)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
