using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAppRoleDal : GenericRepository<AppRole>, IAppRoleDal
{
    public EfAppRoleDal(SignalRContext context) : base(context)
    {
    }
}