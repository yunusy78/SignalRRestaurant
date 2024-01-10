using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AboutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}