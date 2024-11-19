using Microsoft.EntityFrameworkCore;

namespace User.Api.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserClass> Users { get; set; }
    }
}
