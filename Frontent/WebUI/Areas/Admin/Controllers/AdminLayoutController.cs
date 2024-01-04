using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminLayoutController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}