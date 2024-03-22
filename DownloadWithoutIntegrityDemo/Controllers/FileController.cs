using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DownloadWithoutIntegrityDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private const string FilePath = "/path/to/your/file.txt"; // Update with the path to your file

        [HttpGet("download")]
        public IActionResult DownloadFile()
        {
            // Check if the file exists
            if (!System.IO.File.Exists(FilePath))
            {
                return NotFound("File not found");
            }

            // Read the file contents
            byte[] fileBytes = System.IO.File.ReadAllBytes(FilePath);

            // Set the content type and return the file as a downloadable content
            return File(fileBytes, "application/octet-stream", Path.GetFileName(FilePath));
        }
    }
}
