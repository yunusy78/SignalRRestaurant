using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product> , IProductDal
{
    public EfProductDal(SignalRContext context) : base(context)
    {
    }
}
