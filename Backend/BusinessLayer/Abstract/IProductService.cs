using DtoLayer.ProductDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IProductService : IGenericService<Product>
{
    Task<List<ResultProductWithCategoryDto>> GetListWithCategoryAsync();
    
    
}