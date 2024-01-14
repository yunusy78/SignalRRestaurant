using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class SignalRNotificationHub : Hub
{
    private readonly INotificationService _notificationService;


    public SignalRNotificationHub(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    
    
    public async  Task GetNotificationCountByStatus()
    {
        var result = await  _notificationService.GetNotificationCountByStatus();
        await Clients.All.SendAsync("ReceiveNotificationCountByStatus", result);
        
        
        
    }
    
    public async Task GetNotificationListByStatus()
    {
        var result = await _notificationService.GetNotificationListByStatus();
        await Clients.All.SendAsync("ReceiveNotificationListByStatus", result);
    }
}