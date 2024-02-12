using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Displays the login form
        [HttpGet]
        [Route("Login")]
        public IActionResult Index()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        // POST: Processes the login data
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(/* Add parameters to accept login data, e.g., string username, string password */)
        {
            // Here you would typically validate the login data, authenticate the user, etc.
            // For the sake of example, let's just redirect to a "Success" view on successful login.

            // If login is successful
            // return RedirectToAction("Success");

            // If login fails, show the login page again with an error message
            // For simplicity, we're just returning to the same login view.
            // In a real application, you'd likely want to pass a model or ViewData/ViewBag message indicating the failure.
            return View("~/Views/Home/Login.cshtml");
        }
    }
}
