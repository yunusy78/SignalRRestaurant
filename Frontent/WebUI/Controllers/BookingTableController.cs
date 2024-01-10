using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class BookingTableController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}