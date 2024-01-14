using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AppRoleManager : IAppRoleService
{
    private readonly IAppRoleDal _appRoleDal;
    
    public AppRoleManager(IAppRoleDal appRoleDal)
    {
        _appRoleDal = appRoleDal;
    }
    
    public Task<List<AppRole>> GetAllAsync()
    {
        var result = _appRoleDal.GetAllAsync();
        return result;
    }

    public Task<AppRole> GetByIdAsync(int id)
    {
        var result = _appRoleDal.GetByIdAsync(id);
        return result;
    }

    public Task AddAsync(AppRole entity)
    {
        _appRoleDal.AddAsync(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(AppRole entity)
    {
        _appRoleDal.UpdateAsync(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(AppRole entity)
    {
        _appRoleDal.DeleteAsync(entity);
        return Task.CompletedTask;
    }
}