namespace Booking.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int quantity { get; set; }
        public int shopId { get; set; } //manual
        public decimal rating { get; set; }
        public int count { get; set; }
        public decimal cumulativeSum { get; set; }
    }
}
