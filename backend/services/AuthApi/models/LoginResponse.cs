namespace AuthAPI.models
{
    public class LoginResponse
    {
        //public string Id { get; set; }
        public string Token { get; set; } = string.Empty;
        public string email { get; set; }
        public string Role { get; set; }
    }
}
