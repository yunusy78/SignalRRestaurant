using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    public async Task<List<Product>> GetAllAsync()
    {
        return await _productDal.GetAllAsync();
    }
    
    public async Task<Product> GetByIdAsync(int id)
    {
        return await _productDal.GetByIdAsync(id);
    }
    
    public async Task AddAsync(Product entity)
    {
        await _productDal.AddAsync(entity);
    }
    
    public async Task UpdateAsync(Product entity)
    {
        await _productDal.UpdateAsync(entity);
    }
    
    
    public async Task DeleteAsync(Product entity)
    {
        await _productDal.DeleteAsync(entity);
    }
    
    
    
    
    
}