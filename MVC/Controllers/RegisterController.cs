using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using MVC.Models;

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
    }
}
