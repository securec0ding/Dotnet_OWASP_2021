using Microsoft.AspNetCore.Mvc;

namespace AccessControlDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetData(int id)
        {
            // Simulate fetching data from a database
            var data = DataRepository.GetDataById(id);

            // Check if data exists
            if (data == null)
            {
                return NotFound();
            }

            // Return data
            return Ok(data);
        }
    }

    // Simulated data repository
    public static class DataRepository
    {
        public static string GetDataById(int id)
        {
            // In a real application, this method would fetch data from a database
            // For demonstration purposes, we return hardcoded data for specific IDs
            if (id == 1)
            {
                return "Sensitive Data 1";
            }
            else if (id == 2)
            {
                return "Sensitive Data 2";
            }
            else
            {
                return null; // Return null if data for the provided ID does not exist
            }
        }
    }
}
