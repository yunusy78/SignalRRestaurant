using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class SignalRBookingHub : Hub
{
    private readonly IBookingService _bookingService;
    private readonly IDiningTableService _diningTableService;
    
    public SignalRBookingHub(IBookingService bookingService, IDiningTableService diningTableService)
    {
        _bookingService = bookingService;
        _diningTableService = diningTableService;
    }

    public static int count { get; set; }
    
    public async Task GetBookingList()
    {
        var result = await _bookingService.GetAllAsync();
        await Clients.All.SendAsync("ReceiveBookingList", result);
    }
    
    public async Task GetDiningTableList()
    {
        var result = await _diningTableService.GetAllAsync();
        await Clients.All.SendAsync("ReceiveDiningTableList", result);
    }
    
    
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage",user, message);
    }
    
    
    public override async Task OnConnectedAsync()
    {
       count++;
       await Clients.All.SendAsync("ReceiveConnectionCount", count);
       await base.OnConnectedAsync();
    }
    
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        count--;
        await Clients.All.SendAsync("ReceiveConnectionCount", count);
        await base.OnDisconnectedAsync(exception);
    }
}