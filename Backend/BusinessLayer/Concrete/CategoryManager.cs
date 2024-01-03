using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    
    
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    
    
    public async Task<List<Category>> GetAllAsync()
    {
        return await _categoryDal.GetAllAsync();
    }
    
    public async Task<Category> GetByIdAsync(int id)
    {
        return await _categoryDal.GetByIdAsync(id);
    }
    
    public async Task AddAsync(Category entity)
    {
        await _categoryDal.AddAsync(entity);
    }
    
    public async Task UpdateAsync(Category entity)
    {
        await _categoryDal.UpdateAsync(entity);
    }
    
    public async Task DeleteAsync(Category entity)
    {
        await _categoryDal.DeleteAsync(entity);
    }
    
    
}