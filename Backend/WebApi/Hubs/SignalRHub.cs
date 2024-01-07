using BusinessLayer.Abstract;
using Microsoft.AspNetCore.SignalR;

namespace WebApi.Hubs;

public class SignalRHub : Hub
{
    private readonly ISignalRStatisticService _signalRStatisticService;
    
    public SignalRHub(ISignalRStatisticService signalRStatisticService)
    {
        _signalRStatisticService = signalRStatisticService;
    }
    
    public async Task GetTotalProductCount()
    {
        var result = await _signalRStatisticService.GetTotalProductCountAsync();
        await Clients.All.SendAsync("ReceiveTotalProductCount", result);
    }
    
    public async Task GetTotalCategoryCount()
    {
        var result = await _signalRStatisticService.GetTotalCategoryCountAsync();
        await Clients.All.SendAsync("ReceiveTotalCategoryCount", result);
    }
    
}