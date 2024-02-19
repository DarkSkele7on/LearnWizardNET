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
            return View("~/Areas/Identity/Pages/Account/Login.cshtml");
        }
        //
        // // POST: Processes the login data
        // [HttpPost]
        // [Route("Login")]
        // public IActionResult Login(/* Add parameters to accept login data, e.g., string username, string password */)
        // {
        //     return View("~/Views/Home/Login.cshtml");
        // }
    }
}
