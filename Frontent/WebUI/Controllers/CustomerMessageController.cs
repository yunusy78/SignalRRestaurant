using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CustomerMessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}