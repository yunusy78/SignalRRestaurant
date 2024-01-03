using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly ISocialMediaDal _socialMediaDal;
    
    public SocialMediaManager(ISocialMediaDal socialMediaDal)
    {
        _socialMediaDal = socialMediaDal;
    }
    
    
    public async Task<List<SocialMedia>> GetAllAsync()
    {
       return await _socialMediaDal.GetAllAsync();
        
    }
    
    public async Task<SocialMedia> GetByIdAsync(int id)
    {
        return await _socialMediaDal.GetByIdAsync(id);
    }
    
    
    public async Task AddAsync(SocialMedia entity)
    {
        await _socialMediaDal.AddAsync(entity);
        
    }
    
    
    public async Task UpdateAsync(SocialMedia entity)
    {
        await _socialMediaDal.UpdateAsync(entity);
        
    }
    
    
    public async Task DeleteAsync(SocialMedia entity)
    {
        await _socialMediaDal.DeleteAsync(entity);
    }
    
    
}