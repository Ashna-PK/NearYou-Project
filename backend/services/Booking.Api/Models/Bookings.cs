namespace Booking.Api.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int Userid { get; set; }
        public DateTime orderDate { get; set; }
        public double totalAmount {  get; set; }
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
        public double price { get; set; }
        public int quantity { get; set; }
        public int vendorId { get; set; }
        //public List<BookingItem>? orderItems {  get; set; }
        //public List<int> vendorIds { get; set; } =new List<int>();

    }
}
