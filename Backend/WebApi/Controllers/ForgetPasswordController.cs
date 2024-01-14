
using BusinessLayer.Abstract;
using DtoLayer.AppUserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly IAppUserService _userService;
        
        public ForgetPasswordController(IAppUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            // Kullanıcıyı veritabanında e-posta adresine göre bulun
            var user = await _userService.FindByEmail(dto.Email);

            if (user == null)
            {
                // Kullanıcı bulunamadıysa hata döndürün
                return BadRequest("Kullanıcı bulunamadı.");
            }

            // Kullanıcı için sıfırlama bağlantısı oluşturun (örneğin, GUID kullanabilirsiniz)
            // Şifre sıfırlama tokeni oluşturun
            var resetToken = Guid.NewGuid().ToString();

            // Şifre sıfırlama bağlantısını oluşturun
            var resetLink = $"http://localhost:5076/api/ForgetPassword/reset-password?resetToken={resetToken}";
            
            
            // Tokeni ve son kullanma tarihini kullanıcı veritabanına kaydedin
            user.ResetToken = resetToken;
            user.ResetTokenExpiry = DateTime.UtcNow.AddHours(1); // Örneğin, 1 saat geçerli

            // Veritabanındaki değişiklikleri kaydedin
            await _userService.CreateForgotPasswordRecord(user);

            // Kullanıcıya sıfırlama bağlantısı içeren e-posta gönderin
            // E-posta gönderme işlemini burada gerçekleştirin

            // Kullanıcıya bu bağlantıyı ileten bir mesaj veya API yanıtı döndürün
            return Ok(resetToken);
        }


        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string resetToken, string newPassword)
        {
            // Kullanıcıyı veritabanında e-posta adresine göre bulun
            var user = await _userService.FindByEmailFromForgetPassword(resetToken);

            if (user == null)
            {
                // Kullanıcı bulunamadıysa hata döndürün
                return BadRequest("Kullanıcı bulunamadı.");
            }

            // Sıfırlama bağlantısı ve son kullanma tarihini kontrol edin
            if (user.ResetToken == null || user.ResetTokenExpiry < DateTime.UtcNow)
            {
                return BadRequest("Sıfırlama bağlantısı geçersiz veya süresi dolmuş.");
            }

            // Yeni şifreyi hashleyin
            string newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // Kullanıcının şifresini güncelleyin
            user.PasswordHash = newPasswordHash;

            // Kullanılmış sıfırlama bağlantısını temizleyin
            user.ResetToken = null;
            user.ResetTokenExpiry = null;

            // Veritabanındaki değişiklikleri kaydedin
            await _userService.UpdateUser(user);

            return Ok("Password updated successfully");
        }

    }
}
