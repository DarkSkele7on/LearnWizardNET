using Microsoft.AspNetCore.Mvc;
using BusinessLayer;

namespace MVC.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Displays the register form
        [HttpGet]
        [Route("Register")]
        public IActionResult Index()
        {
            return View("~/Views/Home/Register.cshtml");
        }

        // POST: Processes the register data
        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            if (ModelState.IsValid)
            {
                // Implement your logic here to register the user, e.g., saving to a database
                // For now, let's pretend we're saving the user and then redirecting to a login page

                return RedirectToAction("Login");
            }

            // If we got this far, something failed; redisplay form
            return View(model);
        }
    }
}
