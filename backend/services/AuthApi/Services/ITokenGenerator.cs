using AuthAPI.models;

namespace AuthAPI.Services
{
    public interface ITokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
