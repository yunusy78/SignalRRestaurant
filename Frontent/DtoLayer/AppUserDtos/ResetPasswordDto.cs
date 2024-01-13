using System.ComponentModel.DataAnnotations;

namespace DtoLayer.AppUserDtos;

public class ResetPasswordDto
{
   
    public string Email { get; set; }

    
    public string ResetToken { get; set; }
    
    [StringLength(100, ErrorMessage = "Şifre en az {2} ve en fazla {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; }
}