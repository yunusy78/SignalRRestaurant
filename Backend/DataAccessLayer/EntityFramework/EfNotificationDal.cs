using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
{
    private readonly SignalRContext _context;
    public EfNotificationDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> GetNotificationCountByStatus()
    {
        
        var result = await _context.Notifications.CountAsync(x => x.IsRead == false);
        return result;
    }
    
    public async Task<List<Notification>> GetNotificationListByStatus()
    {
        
        var result = await _context.Notifications.Where(x => x.IsRead == false).ToListAsync();
        return result;
    }
}