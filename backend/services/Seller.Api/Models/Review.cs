namespace Seller.Api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int bookingId {  get; set; }
        public int productId { get; set; }
        public int shopid { get; set; }
        public int userid {  get; set; }
        public DateTime dateTime { get; set; }
        public string? Message {  get; set; }
        public decimal userRating { get; set; }

    }
}
