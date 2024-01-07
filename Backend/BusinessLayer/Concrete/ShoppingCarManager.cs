using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ShoppingCartManager : IShoppingCartService
{
    private readonly IShoppingCartDal _shoppingCartDal;
    
    public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
    {
        _shoppingCartDal = shoppingCartDal;
    }
    
    public int IncrementCount(ShoppingCart shoppingCart, int count)
    {
        return _shoppingCartDal.IncrementCount(shoppingCart, count);
    }
    
    public int DecrementCount(ShoppingCart shoppingCart, int count)
    {
        return _shoppingCartDal.DecrementCount(shoppingCart, count);
    }
    
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        return _shoppingCartDal.GetFirstOrDefault(filter, includeProperties, tracked);
    }
    
    public IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter=null, string? includeProperties = null, string? includeProperties2 = null)
    {
        return _shoppingCartDal.GetAllListByFilter(filter, includeProperties, includeProperties2);
    }
    
    public void RemoveRange(IEnumerable<ShoppingCart> entity)
    {
        _shoppingCartDal.RemoveRange(entity);
    }
    
    public async Task<List<ShoppingCart>> GetAllAsync()
    {
        return await _shoppingCartDal.GetAllAsync();
    }

    public async Task<ShoppingCart> GetByIdAsync(int id)
    {
        return await _shoppingCartDal.GetByIdAsync(id);
        
    }

    public async Task AddAsync(ShoppingCart entity)
    {
        await _shoppingCartDal.AddAsync(entity);
        
    }

    public async Task UpdateAsync(ShoppingCart entity)
    {
        await _shoppingCartDal.UpdateAsync(entity);
    }

    public async Task DeleteAsync(ShoppingCart entity)
    {
         await _shoppingCartDal.DeleteAsync(entity);
        
    }
}