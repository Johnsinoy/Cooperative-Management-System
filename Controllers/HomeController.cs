using Cooperative_Financing.Models;
using Cooperative_Financing.Models.ViewModels; // ✅ Make sure this is correct!
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperative_Financing.Controllers
{
    public class HomeController : Controller
    {
        private readonly CooperativeContext _context;

        // ✅ Constructor to inject the database context
        public HomeController(CooperativeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var pageData = new PageViewModel(
                "Home",
                "Welcome to the Cooperative Financing platform.",
                "Home"
            );

            return View(pageData);
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var user = _context.DataUsers.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user != null)
            {
                if (user.Is_Admin)
                {
                    ViewBag.WelcomeMessage = "Welcome, Admin!";
                }
                else
                {
                    ViewBag.WelcomeMessage = "Welcome, Member!";
                }
            }

            ViewBag.Error = "Invalid Member ID or Password";
            return View("Index");
        }

        public IActionResult AdminDashboard()
        {
            return View();
        }

        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
