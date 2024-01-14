using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class NotificationManager : INotificationService
{
    private readonly INotificationDal _notificationDal;
    
    public NotificationManager(INotificationDal notificationDal)
    {
        _notificationDal = notificationDal;
    }
    
    public async Task<List<Notification>> GetAllAsync()
    {
        var notifications = await _notificationDal.GetAllAsync();
        return notifications;
        
    }

    public async Task<Notification> GetByIdAsync(int id)
    {
        var notification = await _notificationDal.GetByIdAsync(id);
        return notification;
    }

    public async Task AddAsync(Notification entity)
    {
        await _notificationDal.AddAsync(entity);
        
    }

    public async Task UpdateAsync(Notification entity)
    {
        await _notificationDal.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Notification entity)
    {
        await _notificationDal.DeleteAsync(entity);
    }
    
    public async Task<int> GetNotificationCountByStatus()
    {
        var result = await _notificationDal.GetNotificationCountByStatus();
        return result;
    }
    
    public async Task<List<Notification>> GetNotificationListByStatus()
    {
        var result = await _notificationDal.GetNotificationListByStatus();
        return result;
    }
}