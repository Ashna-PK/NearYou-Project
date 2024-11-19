using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Models
{
    public class SellerClass
    {
        [Key]
        public int Id { get; set; }
        [Required]     
        public string Name { get; set; } = string.Empty;
        //[Required]
        //public string shopName { get; set; } = string.Empty;
        //public string Description { get; set; }=string.Empty;
        //[Required]
        //public bool isOpen { get; set; }
        //public DateTime openTime { get; set; }
        //public DateTime closeTime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;       //verify email           
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;     //verify number      
        [Required]
        public string Address { get; set; } = string.Empty;                
        [StringLength(100)]
        public string City { get; set; } = string.Empty;                    
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now; //auto         
        public bool IsVerified { get; set; }   //admin   // Flag to show if seller is verified        
        //public decimal rating {  get; set; }    //admin+user
        [StringLength(100)]
        public string BusinessLicense { get; set; }= string.Empty;

    }
}
