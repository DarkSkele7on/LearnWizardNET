using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly LearnWizardDBContext _context;

        public AccountController(LearnWizardDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Ideally, hash the password before saving it to the database
                _context.Add(user);
                await _context.SaveChangesAsync();
                // Redirect to a confirmation page or log the user in directly
                return RedirectToAction("Index", "Home");
            }
            return View(user);
        }
    }
}
