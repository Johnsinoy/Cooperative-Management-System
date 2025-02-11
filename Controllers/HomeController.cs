using Cooperative_Financing.Models.ViewModels; // ✅ Make sure this is correct!
using Microsoft.AspNetCore.Mvc;

namespace Cooperative_Financing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var pageData = new PageViewModel(
                "Home",
                "Welcome to the Cooperative Financing platform.",
                "Home"
            );

            return View(pageData);
        }
    }
}
