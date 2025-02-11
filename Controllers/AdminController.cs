using Cooperative_Financing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cooperative_Financing.Controllers
{
    public class AdminController : Controller
    {
        private readonly CooperativeContext _context;

        public AdminController(CooperativeContext context)
        {
            _context = context;
        }
        // ✅ Load the AddMember view
        [HttpGet]
        public IActionResult AddMember()
        {
            return View("AddMember"); // Explicitly loading AddMember.cshtml
        }

        [HttpPost]
        public IActionResult SaveMember(Members member)
        {
            if (ModelState.IsValid)
            {
                _context.Members.Add(member);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Member added successfully!";
                return RedirectToAction("AddMember");
            }

            return View("AddMember");
        }
    }
}
