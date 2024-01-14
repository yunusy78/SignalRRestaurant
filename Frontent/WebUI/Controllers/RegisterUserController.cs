using System.Text;
using BusinessLayer.Abstract;
using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{

    public class RegisterUserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        
        
        
        public RegisterUserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        // GET
        public IActionResult Index()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserDto model)
        {
            var response = await _authenticationService.RegisterUser(model);
            if (response)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.ErrorMessage = "Username or password is incorrect";
                return RedirectToAction("Index");
            }
        }
    }
}