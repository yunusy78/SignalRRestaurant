using DtoLayer.ShoppingCartDtos;

namespace BusinessLayer.Abstract;

public interface IShoppingCartService :IGenericService<ResultShoppingCart>
{
    
    
   Task<bool> IncrementCount(int cartId, int productId);
   Task<bool> DecrementCount(int cartId, int productId);
    Task<List<ResultShoppingCartWithDiningTableDto>> GetAllListByDiningTableAsync(int diningTableId);
    
    Task<bool> CreateBasketAsync(CreateShoppingCartDto createBasketDto);
    
    Task<bool> RemoveRange(int cartId, int productId);
    
    
    
}