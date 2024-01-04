using BusinessLayer.Abstract;
using DtoLayer.CategoryDtos;

namespace BusinessLayer.Abstract;

public interface ICategoryService : IGenericService<ResultCategoryDto>
{
    Task<bool> AddAsync(CreateCategoryDto categoryDto);
    Task<bool> UpdateAsync(UpdateCategoryDto categoryDto);
    
}