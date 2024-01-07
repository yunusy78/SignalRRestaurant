using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfOrderDetailsDal : GenericRepository<OrderDetails>, IOrderDetailsDal
{
    public EfOrderDetailsDal(SignalRContext context) : base(context)
    {
    }
}