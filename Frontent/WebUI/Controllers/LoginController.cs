using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpClientFactory _clientFactory;
        
        public LoginController(IAuthenticationService authenticationService, IHttpClientFactory clientFactory)
        {
            _authenticationService = authenticationService;
            _clientFactory = clientFactory;
        }
        
        // GET: /Login
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(UserDto model)
        {
            
            // Kullanıcı kimlik doğrulama işlemi
            var token = await GetJwtTokenAsync(model.Email, model.Password);

            if (token != null)
            {
                // JWT ile güvenli kaynağa erişim sağlanır
                var resourceResponse = await AccessSecureResourceAsync(token);

                if (resourceResponse != null)
                {
                    // Kaynak erişimi başarılı oldu, isterseniz bu yanıtı kullanabilirsiniz
                }
                else
                {
                    // Kaynak erişimi başarısız oldu, uygun bir işlem yapabilirsiniz
                }
                
                
                return RedirectToAction("Index", "Default", new {area=""});
            }
            else
            {
                ViewBag.ErrorMessage = "Username or password is incorrect";
                return RedirectToAction("Index");
            }
        }


        private async Task<string> GetJwtTokenAsync(string email, string password)
        {
            var response = await _authenticationService.GetJwtTokenAsync(HttpContext, email, password);
            
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        private async Task<string> AccessSecureResourceAsync(string token)
        {
            var response = await _authenticationService.AccessSecureResourceAsync(token);
            
            if (response != null)
            {
                return response;
            }
            else
            {
                return null;
            }
        }
        
        [HttpGet]
        public IActionResult IsAuthenticated()
        {
            string jwtToken = Request.Cookies["JwtToken"];

            bool isAuthenticated = !string.IsNullOrEmpty(jwtToken);
            
            return Ok(isAuthenticated);
        }
        
        [HttpGet]
        public async Task<IActionResult> IsAdmin()
        {
            var response = await _authenticationService.IsAdmin(HttpContext);
            
            if (response)
            {
                bool isAdmin = true;
                return Ok(isAdmin);
            }
            else
            {
                bool isAdmin = false;
                return Ok(isAdmin);
            }
           
        }
        

    }
}
