using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;

namespace BusinessLayer.Concrete;

public class SignalRStatisticManager : ISignalRStatisticService
{
    private readonly ISignalRStatisticDal _signalRStatisticDal;
    
    public SignalRStatisticManager(ISignalRStatisticDal signalRStatisticDal)
    {
        _signalRStatisticDal = signalRStatisticDal;
    }
    public async Task<int> GetTotalProductCountAsync()
    {
      var result= await _signalRStatisticDal.GetTotalProductCountAsync();
      return result;
        
    }

    public async Task<int> GetTotalCategoryCountAsync()
    {
       var result = await _signalRStatisticDal.GetTotalCategoryCountAsync();
       return result;
    }
    
    
    public async Task<int> GetTotalActiveBookingCountAsync()
    {
        var result = await _signalRStatisticDal.GetTotalActiveBookingCountAsync();
        return result;
    }
    
    
    public async Task<int> GetTotalPassiveBookingCountAsync()
    {
        var result = await _signalRStatisticDal.GetTotalPassiveBookingCountAsync();
        return result;
    }
    
    
    public async Task<decimal> GetAveragePriceAsync()
    {
        var result = await _signalRStatisticDal.GetAveragePriceAsync();
        return result;
    }
    
    
    public async Task<string> GetCheapestProductAsync()
    {
        var result = await _signalRStatisticDal.GetCheapestProductAsync();
        return result;
    }
    
    
    public async Task<string> GetExpensiveProductAsync()
    {
        var result = await _signalRStatisticDal.GetExpensiveProductAsync();
        return result;
    }
    
    
    public async Task<int> GetTotalProductCountByCategoryAsync(int categoryId)
    {
        var result = await _signalRStatisticDal.GetTotalProductCountByCategoryAsync(categoryId);
        return result;
    }
    
    
    public async Task<string> GetTotalProductCountByCategoryNameAsync(string categoryName)
    {
        var result = await _signalRStatisticDal.GetTotalProductCountByCategoryNameAsync(categoryName);
        return result;
    }
    
    
    public async Task<int> GetTotalOrderCountAsync()
    {
        var result = await _signalRStatisticDal.GetTotalOrderCountAsync();
        return result;
    }
    
    
    public async Task<int> GetTodayTotalCompletedOrderCountAsync()
    {
        var result = await _signalRStatisticDal.GetTodayTotalCompletedOrderCountAsync();
        return result;
    }
    
    
    public async Task<decimal> GetTotalCashRevenueAsync()
    {
        var result = await _signalRStatisticDal.GetTotalCashRevenueAsync();
        return result;
    }
    
    
    public async Task<int> GetTotalActiveTableCountAsync()
    {
        var result = await _signalRStatisticDal.GetTotalActiveTableCountAsync();
        return result;
    }
    
    
    
}