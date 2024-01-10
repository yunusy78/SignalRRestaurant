using System.Linq.Expressions;
using DtoLayer.ShoppingCartDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IShoppingCartService :IGenericService<ShoppingCart>
{
    
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true);
    
    IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter=null, string? includeProperties = null, string? includeProperties2 = null);
    
    void RemoveRange(int cartId, int productId);
    
    int IncrementCount(int cartId, int productId);
    int DecrementCount(int cartId, int productId);
    
    Task<List<ResultShoppingCartWithDiningTableDto>> GetAllListByDiningTableAsync(int diningTableId);
    
    Task<CreateShoppingCartDto> CreateBasketAsync(CreateShoppingCartDto createBasketDto);
    
    
    
    
}