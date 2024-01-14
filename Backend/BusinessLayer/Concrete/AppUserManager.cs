using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.AppUserDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;


    public AppUserManager(IAppUserDal appUserDal)
    {
        _appUserDal = appUserDal;
    }
    
    public async Task<List<ApplicationUserDto>> GetAllUserAsync()
    {
        return await _appUserDal.GetAllUserAsync();
    }
    
    public async Task<bool> RegisterUser(ApplicationUserDto applicationUserDto)
    {
        return await _appUserDal.RegisterUser(applicationUserDto);
    }
    
    
    public async Task<ApplicationUserDto> AuthenticateUser(string userName, string password)
    {
        return await _appUserDal.AuthenticateUser(userName, password);
    }
    
    
    public async Task<string> GetRolesForUser(ApplicationUserDto dto)
    {
        return await _appUserDal.GetRolesForUser(dto);
    }
    
    
    public async Task<ForgotPasswordDto> FindByEmail(string email)
    {
        return await _appUserDal.FindByEmail(email);
    }
    
    
    public async Task<bool> UpdateUser(ForgotPasswordDto dto)
    {
        return await _appUserDal.UpdateUser(dto);
    }
    
    
    public async Task<ForgotPasswordDto> FindByEmailFromForgetPassword(string email)
    {
        return await _appUserDal.FindByEmailFromForgetPassword(email);
    }
    
    
    public async Task<bool> CreateForgotPasswordRecord(ForgotPasswordDto dto)
    {
        return await _appUserDal.CreateForgotPasswordRecord(dto);
    }
    
    
    
    
}