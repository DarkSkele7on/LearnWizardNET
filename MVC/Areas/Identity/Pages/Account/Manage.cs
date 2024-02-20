using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Identity.Pages.Account;

public class Manage : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}