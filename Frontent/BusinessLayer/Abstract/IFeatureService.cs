using BusinessLayer.Abstract;
using DtoLayer.FeatureDtos;

namespace BusinessLayer.Abstract;

public interface IFeatureService : IGenericService<ResultFeatureDto>
{
    
    Task<bool> AddAsync(CreateFeatureDto entity);
    Task<bool> UpdateAsync(UpdateFeatureDto entity);
    
}