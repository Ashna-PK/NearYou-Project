using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Data
{
    public class ShopLoginDto
    {
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [StringLength(10)]
        public string PhoneNo { get; set; } = string.Empty;
    }
}
