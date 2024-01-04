using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDtos;

namespace BusinessLayer.Abstract;

public interface ISocialMediaService : IGenericService<ResultSocialMediaDto>
{
    
    Task<bool> AddAsync(CreateSocialMediaDto socialMediaDto);
    Task<bool> UpdateAsync(UpdateSocialMediaDto socialMediaDto);
    
    
}