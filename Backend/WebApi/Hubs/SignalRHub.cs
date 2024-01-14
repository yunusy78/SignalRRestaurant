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
    
    public async Task GetTotalActiveBookingCount()
    {
        var result = await _signalRStatisticService.GetTotalActiveBookingCountAsync();
        await Clients.All.SendAsync("ReceiveTotalActiveBookingCount", result);
    }
    
    public async Task GetTotalPassiveBookingCount()
    {
        var result = await _signalRStatisticService.GetTotalPassiveBookingCountAsync();
        await Clients.All.SendAsync("ReceiveTotalPassiveBookingCount", result);
    }
    
    public async Task GetAveragePrice()
    {
        var result = await _signalRStatisticService.GetAveragePriceAsync();
        await Clients.All.SendAsync("ReceiveAveragePrice", result);
    }
    
    public async Task GetCheapestProduct()
    {
        var result = await _signalRStatisticService.GetCheapestProductAsync();
        await Clients.All.SendAsync("ReceiveCheapestProduct", result);
    }
    
    public async Task GetExpensiveProduct()
    {
        var result = await _signalRStatisticService.GetExpensiveProductAsync();
        await Clients.All.SendAsync("ReceiveExpensiveProduct", result);
    }
    
    public async Task GetTotalProductCountByCategory(int categoryId)
    {
        var result = await _signalRStatisticService.GetTotalProductCountByCategoryAsync(categoryId);
        await Clients.All.SendAsync("ReceiveTotalProductCountByCategory", result);
    }
    
    public async Task GetTotalProductCountByCategoryName(string categoryName)
    {
        var result = await _signalRStatisticService.GetTotalProductCountByCategoryNameAsync(categoryName);
        await Clients.All.SendAsync("ReceiveTotalProductCountByCategoryName", result);
    }
    
    public async Task GetTotalOrderCount()
    {
        var result = await _signalRStatisticService.GetTotalOrderCountAsync();
        await Clients.All.SendAsync("ReceiveTotalOrderCount", result);
    }
    
    
    public async Task GetTodayTotalCompletedOrderCount()
    {
        var result = await _signalRStatisticService.GetTodayTotalCompletedOrderCountAsync();
        await Clients.All.SendAsync("ReceiveTodayTotalCompletedOrderCount", result);
    }
    
    
    public async Task GetTotalCashRevenue()
    {
        var result = await _signalRStatisticService.GetTotalCashRevenueAsync();
        await Clients.All.SendAsync("ReceiveTotalCashRevenue", result);
    }
    
    
    public async Task GetTotalActiveTableCount()
    {
        var result = await _signalRStatisticService.GetTotalActiveTableCountAsync();
        await Clients.All.SendAsync("ReceiveTotalActiveTableCount", result);
    }
    
    
    public async Task GetTotalPassiveTableCount()
    {
        var result = await _signalRStatisticService.GetTotalPassiveTableCountAsync();
        await Clients.All.SendAsync("ReceiveTotalPassiveTableCount", result);
    }
    
    
    
    public async Task SendProgress()
    {
        var result1 = await _signalRStatisticService.GetTotalProductCountAsync();
        await Clients.All.SendAsync("ReceiveTotalProductCount", result1);
      
        var result3 = await _signalRStatisticService.GetTotalActiveBookingCountAsync();
        await Clients.All.SendAsync("ReceiveTotalActiveBookingCount", result3);
        
        var result4 = await _signalRStatisticService.GetAveragePriceAsync();
        await Clients.All.SendAsync("ReceiveAveragePrice", result4);
        
        var result5 = await _signalRStatisticService.GetTotalCashRevenueAsync();
        await Clients.All.SendAsync("ReceiveTotalCashRevenue", result5);
        
        var result6 = await _signalRStatisticService.GetTotalActiveTableCountAsync();
        await Clients.All.SendAsync("ReceiveTotalActiveTableCount", result6);
        
        var result2 = await _signalRStatisticService.GetTotalPassiveTableCountAsync();
        await Clients.All.SendAsync("ReceiveTotalPassiveTableCount", result2);
    }
    
    
    
    
    
    
    
}