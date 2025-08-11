using ApplicationRoleManagementSystem1.Data;
using ApplicationRoleManagementSystem1.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ApplicationRoleManagementSystem1.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show Registration Form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Handle Form Submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("", "Application name is required.");
                return View();
            }

            // Generate unique AppId and AppKey
            string appId = Guid.NewGuid().ToString();
            string appKey = GenerateSecureKey();

            var newApp = new ApplicationModel
            {
                Name = name,
                AppId = appId,
                AppKey = appKey,
                Status = ApplicationStatus.PendingApproval,
                CreatedAt = DateTime.UtcNow
            };

            _context.Applications.Add(newApp);
            _context.SaveChanges();

            ViewBag.Message = "Your application has been registered and is pending approval.";
            ViewBag.AppId = appId;
            ViewBag.AppKey = appKey;

            return View("RegisterSuccess");
        }

        // Secure random key generator
        private string GenerateSecureKey()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[32];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
