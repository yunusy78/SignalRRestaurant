using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactDal : GenericRepository<Contact> , IContactDal
{
    public EfContactDal(SignalRContext context) : base(context)
    {
    }
}