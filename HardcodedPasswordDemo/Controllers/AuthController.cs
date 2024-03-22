using Microsoft.AspNetCore.Mvc;

namespace HardcodedPasswordDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private const string HardcodedPassword = "password123";

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Password == HardcodedPassword)
            {
                return Ok("Login successful");
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }
        }
    }

    public class LoginRequest
    {
        public string Password { get; set; }
    }
}
