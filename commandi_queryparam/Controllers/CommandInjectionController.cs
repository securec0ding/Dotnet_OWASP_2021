// Controllers/CommandInjectionController.cs

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace commandi_queryparam.Controllers
{
    public class CommandInjectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c {command}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processInfo);
            process.WaitForExit();

            ViewBag.Output = process.StandardOutput.ReadToEnd();

            return View("CommandResult");
        }
    }
}
