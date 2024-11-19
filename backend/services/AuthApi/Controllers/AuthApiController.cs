using AuthAPI.models;
using AuthAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public AuthApiController(IRegisterService registerService)
        {
            _registerService = registerService;
        }



        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterRequestDto register)
        {
            Result response = new Result()
            {
                result = await _registerService.RegisterUser(register)
            };
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _registerService.Login(loginRequest);
            return Ok(result);
        }
        
    }
    public class Result
    {
        public string result { get; set; }
    }
}
