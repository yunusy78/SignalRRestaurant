using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.Controllers;

public class LogoutController : Controller
{
    private readonly IAuthenticationService _authenticationService;
    
    public LogoutController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout()
    {

        var response = await _authenticationService.Logout();

        if (response)
        {
            // Logout işlemi başarılı oldu
            
            HttpContext.Response.Cookies.Delete("JwtToken");
            return RedirectToAction("Index", "Default");
        }
        else
        {
            // Logout işlemi başarısız oldu
            return RedirectToAction("Index", "Login");
        }
    
    }
}