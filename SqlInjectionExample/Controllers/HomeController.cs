using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SqlInjectionExample.Data;
using System;

namespace SqlInjectionExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

         [HttpPost]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Login(string username, string password)
        {
            // Construct SQL query string with user-supplied input (vulnerable to SQL injection)
            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";

            // Execute SQL query
            var user = _context.Users.FromSqlRaw(query).FirstOrDefault();

            if (user != null)
            {
                // If login is successful, redirect to a different action or view
                return RedirectToAction("LoggedIn");
            }
            else
            {
                // If login fails, print a message to the console
                Console.WriteLine("Login attempt failed for username: " + username);
                
                // Set ViewBag message for displaying in the view
                ViewBag.Message = "Invalid username or password.";

                return View("Res");
            }
        }

        
        // Action method to handle logged-in users
        public IActionResult LoggedIn()
        {
            // Add any logic to handle logged-in users
            return View();
        }
    }
}
