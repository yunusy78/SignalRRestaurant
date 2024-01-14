using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface INotificationDal : IGenericDal<Notification>
{
    Task<int> GetNotificationCountByStatus();
    Task<List<Notification>> GetNotificationListByStatus();

}