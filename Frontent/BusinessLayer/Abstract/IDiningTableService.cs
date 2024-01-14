using DtoLayer.AboutDtos;
using DtoLayer.DiningTableDtos;

namespace BusinessLayer.Abstract;

public interface IDiningTableService : IGenericService<ResultDiningTableDto>
{
    Task<bool> AddAsync(CreateDiningTableDto entity);
    Task<bool> UpdateAsync(UpdateDiningTableDto entity);
    
}