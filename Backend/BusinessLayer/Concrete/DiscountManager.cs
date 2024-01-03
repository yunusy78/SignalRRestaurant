using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class DiscountManager : IDiscountService
{
    private readonly IDiscountDal _discountDal;

    public DiscountManager(IDiscountDal discountDal)
    {
        _discountDal = discountDal;
    }
    
    
    public async Task<List<Discount>> GetAllAsync()
    {
        return await _discountDal.GetAllAsync();
    }
    
    public async Task<Discount> GetByIdAsync(int id)
    {
        return await _discountDal.GetByIdAsync(id);
    }
    
    
    public async Task AddAsync(Discount entity)
    {
        await _discountDal.AddAsync(entity);
    }
    
    
    
    public async Task UpdateAsync(Discount entity)
    {
        await _discountDal.UpdateAsync(entity);
    }
    
    
    
    public async Task DeleteAsync(Discount entity)
    {
        await _discountDal.DeleteAsync(entity);
    }
    
    
}