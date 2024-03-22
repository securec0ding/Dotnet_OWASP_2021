using Microsoft.AspNetCore.Mvc;
using SSRFExample.Data;
using SSRFExample.Models;
using System;
using System.Net;

namespace SSRFExample.Controllers
{
    public class UrlDataController : Controller
    {
        private readonly AppDbContext _context;

        public UrlDataController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitUrl(UrlData urlData)
        {
            string response = null; // Declare response variable outside the try block

            try
            {
                // Create a WebClient instance to make the HTTP request
                using (var client = new WebClient())
                {
                    // Send a request to the URL specified in urlData.Url
                    response = client.DownloadString(urlData.Url);

                    // Log the response (For demonstration purposes only, should be handled securely)
                    Console.WriteLine($"Response from {urlData.Url}: {response}");
                }

                // Add URL data to the database
                //_context.UrlData.Add(urlData);
                //_context.SaveChanges();

                // Set ViewBag message for displaying in the view
                ViewBag.Message = response;

                return View("Res");
            }
            catch (Exception ex)
            {
                // Handle exceptions (For demonstration purposes only, should be handled securely)
                Console.WriteLine($"An error occurred: {ex.Message}");
                return View("Res");
                //return RedirectToAction("Index"); // Redirect to the index page
            }
        }
    }
}
