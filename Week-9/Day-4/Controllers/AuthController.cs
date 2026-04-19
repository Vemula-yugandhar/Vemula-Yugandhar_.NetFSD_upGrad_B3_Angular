using Microsoft.AspNetCore.Mvc;
using AuthService.Services;
using AuthService.Models;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            return Ok(await _service.Register(user));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(User user)
        {
            var token = await _service.Login(user.Email, user.Password);

            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}