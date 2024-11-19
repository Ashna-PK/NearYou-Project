using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Data
{
    public class SellerDto
    { 
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [StringLength(100)]
        public string City { get; set; } = string.Empty;
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;        
        [StringLength(100)]
        public string BusinessLicense { get; set; } = string.Empty;

    }
}
