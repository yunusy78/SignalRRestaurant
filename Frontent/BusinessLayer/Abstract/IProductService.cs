
using BusinessLayer.Abstract;
using DtoLayer.ProductDtos;

namespace BusinessLayer.Abstract;

public interface IProductService : IGenericService<ResultProductDto>
{
    Task<bool> AddAsync(CreateProductDto dto);
    Task<bool> UpdateAsync(UpdateProductDto dto);
    
}