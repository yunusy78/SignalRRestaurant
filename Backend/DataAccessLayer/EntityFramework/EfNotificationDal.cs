using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    public EfNotificationDal(SignalRContext context) : base(context)
    {
    }

    public async Task<int> GetNotificationCountByStatus()
    {
        var context = new SignalRContext();
        var result = await context.Notifications.CountAsync(x => x.IsRead == false);
        return result;
    }
    
    public async Task<List<Notification>> GetNotificationListByStatus()
    {
        var context = new SignalRContext();
        var result = await context.Notifications.Where(x => x.IsRead == false).ToListAsync();
        return result;
    }
}