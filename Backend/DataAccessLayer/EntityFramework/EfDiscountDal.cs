using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>  , IDiscountDal
{
    public EfDiscountDal(SignalRContext context) : base(context)
    {
    }
    
    public async Task<int> CheckDiscountCodeAsync(string code)
    {
        var context= new SignalRContext();
        var result =await context.Discounts.AnyAsync(x => x.Code == code);
        if (result)
        {
            var discount = await context.Discounts.FirstOrDefaultAsync(x => x.Code == code);
            return discount!.Amount;
        }
        else
        {
            return 0;
        }
    }
}