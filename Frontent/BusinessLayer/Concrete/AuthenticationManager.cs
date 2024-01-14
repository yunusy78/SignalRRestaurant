using System.Net.Http.Headers;
using System.Text;
using Azure.Core;
using BusinessLayer.Abstract;
using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class AuthenticationManager : IAuthenticationService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    public AuthenticationManager(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    
    
    public async Task<string> GetJwtTokenAsync(HttpContext httpContext, string email, string password)
    {
        
        var authRequest = new
        {
            Email = email,
            Password = password
        };
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var content = new StringContent(JsonConvert.SerializeObject(authRequest), Encoding.UTF8, "application/json");
        
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Auth.Path}/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeAnonymousType(tokenResponse, new { token = "" });
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // JavaScript tarafından erişilemez
                    Expires = DateTime.UtcNow.AddHours(1) // Tokenin süresini ayarlayın
                };


                httpContext.Response.Cookies.Append("JwtToken", token!.token, cookieOptions);

                return token.token;
            }
            else
            {
                return null;
            }

        
    }

    public async Task<string> AccessSecureResourceAsync(string token)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Product.Path}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        return null;
    }

    public Task<bool> IsAuthenticated()
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> Logout()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Auth.Path}/Logout", null);

        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> ResetPassword(string resetToken, string newPassword)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ForgetPassword.Path}/reset-password?resetToken={resetToken}&newPassword={newPassword}",null);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public Task<bool> ForgotPassword(ForgotPasswordDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterUser(RegisterUserDto model)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Register.Path}", content);
        var result = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
           return true;
        }
        else
        {
            return false;


        }
    }
    
    
    public async Task<bool> IsAdmin(HttpContext httpContext)
    {
        var jwtToken = httpContext.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Category.Path}/CategoriesAdmin");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}