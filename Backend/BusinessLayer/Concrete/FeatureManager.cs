using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IFeatureDal _featureDal;

    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }
    
    public async Task<List<Feature>> GetAllAsync()
    {
        return await _featureDal.GetAllAsync();
    }
    
    
    public async Task<Feature> GetByIdAsync(int id)
    {
        return await _featureDal.GetByIdAsync(id);
    }
    
    
    public async Task AddAsync(Feature entity)
    {
        await _featureDal.AddAsync(entity);
    }
    
    
    public async Task UpdateAsync(Feature entity)
    {
        await _featureDal.UpdateAsync(entity);
    }
    
    
    public async Task DeleteAsync(Feature entity)
    {
        await _featureDal.DeleteAsync(entity);
    }
    
}