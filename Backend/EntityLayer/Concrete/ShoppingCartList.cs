using EntityLayer.Concrete;

namespace EntityLayer.Concrete;

public class ShoppingCartList
{
    public IEnumerable<ShoppingCart> Carts { get; set; }
    
    public Order Order { get; set; }
}