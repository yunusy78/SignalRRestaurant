using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.ShoppingCartDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ShoppingCartManager : IShoppingCartService
{
    private readonly IShoppingCartDal _shoppingCartDal;
    
    public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
    {
        _shoppingCartDal = shoppingCartDal;
    }
    
    public int IncrementCount(int cartId, int productId)
    {
        return _shoppingCartDal.IncrementCount(cartId, productId);
    }
    
    public int DecrementCount(int cartId, int productId)
    {
        return _shoppingCartDal.DecrementCount(cartId, productId);
    }
    
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        return _shoppingCartDal.GetFirstOrDefault(filter, includeProperties, tracked);
    }
    
    public IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter=null, string? includeProperties = null, string? includeProperties2 = null)
    {
        return _shoppingCartDal.GetAllListByFilter(filter, includeProperties, includeProperties2);
    }
    
    public void RemoveRange(int cartId, int productId)
    {
        _shoppingCartDal.RemoveRange(cartId, productId);
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
    
    public async Task<List<ResultShoppingCartWithDiningTableDto>> GetAllListByDiningTableAsync(int diningTableId)
    {
        return await _shoppingCartDal.GetAllListByDiningTableAsync(diningTableId);
    }
    
    public async Task<CreateShoppingCartDto> CreateBasketAsync(CreateShoppingCartDto createBasketDto)
    {
        return await _shoppingCartDal.CreateBasketAsync(createBasketDto);
    }
}