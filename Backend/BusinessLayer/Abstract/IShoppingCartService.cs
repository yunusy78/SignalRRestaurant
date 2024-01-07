using System.Linq.Expressions;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IShoppingCartService :IGenericService<ShoppingCart>
{
    int IncrementCount(ShoppingCart shoppingCart, int count);
    int DecrementCount(ShoppingCart shoppingCart, int count);
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true);
    
    IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter=null, string? includeProperties = null, string? includeProperties2 = null);
    
    void RemoveRange(IEnumerable<ShoppingCart> entity);
    
    
}