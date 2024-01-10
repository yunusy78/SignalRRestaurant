using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}