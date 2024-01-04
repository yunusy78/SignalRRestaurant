
using DtoLayer.AboutDtos;

namespace BusinessLayer.Abstract;

public interface IAboutService : IGenericService<ResultAboutDto>
{
    
    Task<bool> AddAsync(CreateAboutDto aboutDto);
    Task<bool> UpdateAsync(UpdateAboutDto aboutDto);
    
}