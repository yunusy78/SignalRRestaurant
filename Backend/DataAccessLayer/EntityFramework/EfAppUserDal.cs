using AutoMapper;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.AppUserDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfAppUserDal :IAppUserDal
{
    private readonly SignalRContext _context;
    private readonly IMapper _mapper;
    
    public EfAppUserDal(SignalRContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<ApplicationUserDto>> GetAllUserAsync()
    {
        var result = await _context.AppUsers.ToListAsync();
        var result2=_mapper.Map<List<ApplicationUserDto>>(result);
        return result2;
    }

    public async Task<bool> RegisterUser(ApplicationUserDto applicationUserDto)
    {
        try
        {
            // Yeni kullanıcıyı veritabanına eklemek için Entity Framework kullanımı
            _context.AppUsers.Add(new AppUser
            {
                UserEmail = applicationUserDto.UserEmail,
                PasswordHash = applicationUserDto.PasswordHash
            });

            var affectedRows = await _context.SaveChangesAsync();

            // Etkilenen satır sayısını kontrol edin
            return affectedRows > 0;
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return false;
        }
    }


    public async Task<ApplicationUserDto> AuthenticateUser(string userName, string password)
    {
        try
        {
            // Kullanıcıyı kullanıcı adına göre veritabanından bulun
            var user = await _context.AppUsers.SingleOrDefaultAsync(u => u.UserEmail == userName);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                var userDto = _mapper.Map<ApplicationUserDto>(user);
                return userDto;
            }
            else
            {
                // Kullanıcı bulunamadı veya şifre doğrulanamadı
                return null;
            }
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return null;
        }
    }

    public async Task<string> GetRolesForUser(ApplicationUserDto dto)
    {
        try
        {
            var user = await _context.AppUsers.SingleOrDefaultAsync(u => u.UserEmail == dto.UserEmail);

            if (user != null)
            {
                var roles = await _context.AppUserRoles
                    .Where(u => u.AppUserId == user.UserId)
                    .ToListAsync();

                var roleNames = await _context.AppRoles
                    .Where(r=>r.AppRoleId==roles.Select(u=>u.AppRoleId).FirstOrDefault())
                    .Select(r => r.AppRoleName)
                    .ToListAsync();

                var roleNamesString = string.Join(",", roleNames);
                return roleNamesString;
            }
            else
            {
                // Kullanıcı bulunamadıysa veya hata oluştuysa uygun bir değer döndürün
                return "Kullanıcı bulunamadı veya hata oluştu";
            }
            
        }
        catch (Exception ex)
        {
            // Hata işleme burada
            // Loglama veya hata mesajı döndürme
            return null;
        }
    }


    public Task<ForgotPasswordDto> FindByEmail(string email)
    {
        var user = _context.AppUsers.FirstOrDefault(u => u.UserEmail == email);
        var userDto = _mapper.Map<ForgotPasswordDto>(user);
        return Task.FromResult(userDto);
    }

    public Task<bool> UpdateUser(ForgotPasswordDto dto)
    {
        var user = _context.AppUsers.FirstOrDefault(u => u.UserEmail == dto.Email);
        user.PasswordHash = dto.PasswordHash;
        _context.AppUsers.Update(user);
        _context.SaveChanges();
        return Task.FromResult(true);
        
    }

    public Task<ForgotPasswordDto> FindByEmailFromForgetPassword(string email)
    {
        var user = _context.AppUsers.FirstOrDefault(u => u.UserEmail == email);
        var userDto = _mapper.Map<ForgotPasswordDto>(user);
        return Task.FromResult(userDto);
    }

    public Task<bool> CreateForgotPasswordRecord(ForgotPasswordDto dto)
    {
        _context.ForgotPasswords.Add(new ForgotPassword
        {
            Email = dto.Email,
            ResetToken = dto.ResetToken,
            ResetTokenExpires = dto.ResetTokenExpiry
        });
        _context.SaveChanges();
        return Task.FromResult(true);
    }
}