using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IDiscountService : IGenericService<Discount>
{
    
    Task<int> CheckDiscountCodeAsync(string code);
    
}