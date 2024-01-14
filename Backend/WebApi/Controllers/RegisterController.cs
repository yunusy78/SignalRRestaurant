using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAppUserService _appService;
        
        public RegisterController(IAppUserService appService)
        {
            _appService = appService;
        }

        

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Şifreyi hashle
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        
                // Kullanıcı bilgilerini ApplicationUserDto'dan çıkar
                var user = new ApplicationUserDto()
                {
                    UserEmail = model.Email,
                    PasswordHash = passwordHash
                };

                // Kullanıcı kaydı işlemi
                var userRegistered = await _appService.RegisterUser(user);

                if (userRegistered)
                {
                    return Ok("User registered successfully");
                }
                else
                {
                    return BadRequest("User registration failed");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    
    }
}