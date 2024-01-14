using DtoLayer.AppUserDtos;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IAppUserDal
{
    Task<List<ApplicationUserDto>> GetAllUserAsync();
    Task<bool> RegisterUser(ApplicationUserDto applicationUserDto);
    Task<ApplicationUserDto> AuthenticateUser(string userName, string password);
    Task<string> GetRolesForUser(ApplicationUserDto dto);
    
    Task<ForgotPasswordDto> FindByEmail(string email);
    
    Task<bool> UpdateUser(ForgotPasswordDto dto);
    Task<ForgotPasswordDto> FindByEmailFromForgetPassword(string email);
    
    Task<bool> CreateForgotPasswordRecord(ForgotPasswordDto dto);
    
}