using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        [Route("About")]
        public IActionResult Index()
        {
            return View("~/Views/Home/About.cshtml");
        }
    }
}
