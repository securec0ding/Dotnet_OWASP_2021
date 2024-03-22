using Microsoft.AspNetCore.Mvc;

namespace SecurityMisconfig.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok("This is public data accessible to everyone.");
        }

        [HttpGet("private")]
        public IActionResult GetPrivateData()
        {
            var userId = User.FindFirst("sub")?.Value;
            if (userId != "admin")
            {
                return Forbid();
            }

            var sensitiveData = _dataService.GetSensitiveData();
            return Ok(sensitiveData);
        }
    }
}
