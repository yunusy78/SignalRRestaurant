using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Abstract;

public interface IAuthenticationService
{
    Task<string> GetJwtTokenAsync(HttpContext httpContext, string email, string password);
    Task<string> AccessSecureResourceAsync(string token);
    Task<bool> IsAuthenticated();
    Task<bool> IsAdmin(HttpContext httpContext);
    Task<bool> Logout();
    Task<bool> ResetPassword(string resetToken, string newPassword);
    Task<bool> ForgotPassword(ForgotPasswordDto dto);
    Task<bool> RegisterUser(RegisterUserDto model);
}