using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class MenuController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}