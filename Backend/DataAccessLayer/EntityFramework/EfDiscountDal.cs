using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>  , IDiscountDal
{
    private readonly SignalRContext _context;
    public EfDiscountDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<int> CheckDiscountCodeAsync(string code)
    {
        
        var result =await _context.Discounts.AnyAsync(x => x.Code == code);
        if (result)
        {
            var discount = await _context.Discounts.FirstOrDefaultAsync(x => x.Code == code);
            return discount!.Amount;
        }
        else
        {
            return 0;
        }
    }
}