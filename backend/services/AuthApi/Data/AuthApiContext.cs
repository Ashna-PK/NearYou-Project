using AuthAPI.models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data
{
    public class AuthApiContext:IdentityDbContext<ApplicationUser>
    {
        public AuthApiContext(DbContextOptions<AuthApiContext> options) : base(options) { }


    }
}
