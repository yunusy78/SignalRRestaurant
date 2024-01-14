using DtoLayer.ContactDtos;
using DtoLayer.MessageDtos;
using DtoLayer.NotificationDtos;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BusinessLayer.Abstract;

public interface INotificationService : IGenericService<ResultNotificationDto>
{
    Task<bool> AddAsync(CreateNotificationDto dto);
    Task<bool> UpdateAsync(UpdateNotificationDto dto);
    
    int GetNotificationCountByStatus();
}