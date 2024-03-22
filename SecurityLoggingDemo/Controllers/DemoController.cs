using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace SecurityLoggingDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("throw-exception")]
        public IActionResult ThrowException()
        {
            try
            {
                // Simulate a failure by throwing an exception
                throw new Exception("Simulated failure occurred");
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An error occurred while processing the request");

                // Return a 500 Internal Server Error response
                return StatusCode(500, "An error occurred while processing the request");
            }
        }
    }
}
