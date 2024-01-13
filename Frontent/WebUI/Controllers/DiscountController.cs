using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class DiscountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}