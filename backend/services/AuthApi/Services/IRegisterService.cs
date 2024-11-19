using AuthAPI.models;

namespace AuthAPI.Services
{
    public interface IRegisterService
    {
        public Task<string> RegisterUser(RegisterRequestDto requestDto);
        public Task<LoginResponse> Login(LoginRequest loginRequest);
    }
}
