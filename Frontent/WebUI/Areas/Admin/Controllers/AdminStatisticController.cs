using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminStatisticController : Controller
{
    private readonly IConfiguration _configuration;
    
    public AdminStatisticController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // GET
    public IActionResult Index()
    {
        var hubUrl = _configuration.GetSection("SignalRHubSettings:HubUrl").Value;
        ViewBag.HubUrl = hubUrl;
        return View();
    }
}