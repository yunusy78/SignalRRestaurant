using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfBookingDal: GenericRepository<Booking> , IBookingDal
{
    public EfBookingDal(SignalRContext context) : base(context)
    {
    }
}