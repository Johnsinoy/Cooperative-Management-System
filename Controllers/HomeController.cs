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
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Username and Password are required.";
                return View("Index");
            }

            var user = _context.DataUsers.FirstOrDefault(u => u.Username == username);

            if (user == null || user.Password != password) // Consider using password hashing
            {
                ViewBag.Error = "Invalid username or password.";
                return View("Index");
            }

            // ✅ Store login session securely
            HttpContext.Session.SetInt32("UserId", user.User_Id);
            HttpContext.Session.SetInt32("IsAdmin", user.Is_Admin ? 1 : 0);

            if (user.Is_Admin)
            {
                return RedirectToAction("AdminDashboard");
            }

            ViewBag.WelcomeMessage = "Welcome, Member!";
            return RedirectToAction("MemberDashboard"); // Redirect members to their dashboard
        }

        [HttpGet]
        public IActionResult AdminDashboard()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            int? isAdmin = HttpContext.Session.GetInt32("IsAdmin");

            // ✅ Check if user is authenticated
            if (userId == null)
            {
                return RedirectToAction("Index");
            }

            // ✅ Restrict non-admin users
            if (isAdmin != 1)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult UserDashboard()
        {
            return View();
        }
    }
}
