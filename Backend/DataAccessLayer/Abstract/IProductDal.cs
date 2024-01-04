using DtoLayer.ProductDtos;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IProductDal : IGenericDal<Product>
{
    Task<List<ResultProductWithCategoryDto>> GetListWithCategoryAsync();
    
}