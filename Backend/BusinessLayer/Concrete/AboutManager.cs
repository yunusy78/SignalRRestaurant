using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }


    public async Task<List<About>> GetAllAsync()
    {
       return await _aboutDal.GetAllAsync();
       
    }

    public async Task<About> GetByIdAsync(int id)
    {
        return await _aboutDal.GetByIdAsync(id);
    }

    public async Task AddAsync(About entity)
    {
        await _aboutDal.AddAsync(entity);
        
    }

    public async Task UpdateAsync(About entity)
    {
        await _aboutDal.UpdateAsync(entity);
        
    }

    public async Task DeleteAsync(About entity)
    {
        await _aboutDal.DeleteAsync(entity);
    }
}
