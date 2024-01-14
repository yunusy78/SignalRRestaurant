using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface INotificationService : IGenericService<Notification>
{
    
    
    Task<int> GetNotificationCountByStatus();
    
    Task<List<Notification>> GetNotificationListByStatus();
    
}