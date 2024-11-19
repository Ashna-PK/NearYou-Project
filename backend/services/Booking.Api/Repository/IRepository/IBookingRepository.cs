using Booking.Api.Models;

namespace Booking.Api.Repository.IRepository
{
    public interface IBookingRepository
    {
        public Task<Bookings> createOrder(Bookings booking);
        //private void sendWhatsappNotification(Bookings order);
        public Task<Bookings?>  getOrderById(int id);
        public Task<List<Bookings>> getOrdersByUserId(int userId);
        //public Task<Bookings> updateOrder(int id, Bookings booking);
        public Task<List<Bookings>> getOrdersByShopId(int shopId);
        public Task<List<Bookings>> getOrders();
        public Task<bool> deleteOrder(int id);
    }
}
