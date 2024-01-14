using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfMessageDal : GenericRepository<Message>, IMessageDal
{
    public EfMessageDal(SignalRContext context) : base(context)
    {
    }
}