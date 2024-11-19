using System.ComponentModel.DataAnnotations;

namespace User.Api.Models
{
    public class userDto
    {
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [StringLength(10)]
        public string PhoneNo { get; set; } = string.Empty;
    }
}
