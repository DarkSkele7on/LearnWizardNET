using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers;

    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Contact.cshtml");
        }
    }

