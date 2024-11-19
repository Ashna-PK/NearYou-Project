using System.ComponentModel.DataAnnotations;

namespace Seller.Api.Data
{
    public class shopDto
    {
        public string Name { get; set; }=string.Empty;
        public string Description { get; set; }= string.Empty;
        public TimeSpan openTime { get; set; }
        public TimeSpan closeTime { get; set; }
        public string Category { get; set; } = string.Empty;
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;       //verify email           
        public string PhoneNumber { get; set; } = string.Empty;
        public bool isOpen { get; set; }  
        public DateTime CreatedAt { get; set; } = DateTime.Now; //auto               

    }
}
