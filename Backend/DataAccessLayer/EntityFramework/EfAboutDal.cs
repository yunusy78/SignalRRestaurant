using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAboutDal : GenericRepository<About>, IAboutDal
{
    public EfAboutDal(SignalRContext context) : base(context)
    {
    }
}