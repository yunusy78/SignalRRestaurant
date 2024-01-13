using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AppUserManager : IAppUserService
{
    private readonly IAppUserDal _appUserDal;
    
    public AppUserManager(IAppUserDal appUserDal)
    {
        _appUserDal = appUserDal;
    }
    
    public Task<List<AppUser>> GetAllAsync()
    {
        var result = _appUserDal.GetAllAsync();
        return result;
    }

    public Task<AppUser> GetByIdAsync(int id)
    {
        var result = _appUserDal.GetByIdAsync(id);
        return result;
    }

    public Task AddAsync(AppUser entity)
    {
        _appUserDal.AddAsync(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(AppUser entity)
    {
        _appUserDal.UpdateAsync(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(AppUser entity)
    {
        _appUserDal.DeleteAsync(entity);
        return Task.CompletedTask;
    }
}