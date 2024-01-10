using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}