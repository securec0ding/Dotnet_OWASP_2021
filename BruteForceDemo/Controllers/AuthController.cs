using Microsoft.AspNetCore.Mvc;

namespace BruteForceDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private const string ValidPassword = "password123";

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Username and password are required.");
            }

            if (model.Password == ValidPassword)
            {
                return Ok("Login successful");
            }
            else
            {
                return Unauthorized("Invalid username or password");
            }
        }

        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
