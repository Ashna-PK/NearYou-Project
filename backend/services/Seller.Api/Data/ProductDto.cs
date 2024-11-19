namespace Seller.Api.Data
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int quantity { get; set; }
        public decimal rating { get; set; } 
    }
}
