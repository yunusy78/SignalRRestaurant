using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class CustomerMessageController : Controller
{
    private readonly IConfiguration _configuration;
    
    public CustomerMessageController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // GET
    public IActionResult Index()
    {
        var hubUrl = _configuration.GetSection("SignalRHubSettings:HubBookingUrl").Value;
        ViewBag.HubUrl = hubUrl!;
        return View();
    }
    
    public IActionResult ClientUserCount()
    {
        var hubUrl = _configuration.GetSection("SignalRHubSettings:HubBookingUrl").Value;
        ViewBag.HubUrl = hubUrl!;
        return View();
    }
}