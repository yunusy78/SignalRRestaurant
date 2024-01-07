using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IShoppingCartDal : IGenericDal<ShoppingCart>
{
    int IncrementCount(ShoppingCart shoppingCart, int count);
    int DecrementCount(ShoppingCart shoppingCart, int count);

    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null,
        bool tracked = true);

    IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter = null,
        string? includeProperties = null, string? includeProperties2 = null);

    void RemoveRange(IEnumerable<ShoppingCart> entity);

    public void SaveChanges();

}
    