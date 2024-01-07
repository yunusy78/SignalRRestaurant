using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class SignalRDefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult SignalR()
    {
        return View();
    }
}