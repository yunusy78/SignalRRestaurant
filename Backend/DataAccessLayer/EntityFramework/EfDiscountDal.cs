using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfDiscountDal : GenericRepository<Discount>  , IDiscountDal
{
    public EfDiscountDal(SignalRContext context) : base(context)
    {
    }
}