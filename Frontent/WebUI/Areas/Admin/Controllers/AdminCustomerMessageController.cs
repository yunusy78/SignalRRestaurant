using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCustomerMessageController : Controller
{
    private readonly IConfiguration _configuration;
    
    public AdminCustomerMessageController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    
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