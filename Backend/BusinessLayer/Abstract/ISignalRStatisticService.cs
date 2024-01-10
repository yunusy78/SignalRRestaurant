namespace BusinessLayer.Abstract;

public interface ISignalRStatisticService
{
    Task<int> GetTotalProductCountAsync();
    Task<int> GetTotalCategoryCountAsync();
    
    Task<int> GetTotalActiveBookingCountAsync();
    
    
    Task<int> GetTotalPassiveBookingCountAsync();
    
    
    Task<decimal> GetAveragePriceAsync();
    
    
    Task<string> GetCheapestProductAsync();
    
    
    Task<string> GetExpensiveProductAsync();
    
    
    Task<int> GetTotalProductCountByCategoryAsync(int categoryId);
    
    
    Task<string> GetTotalProductCountByCategoryNameAsync(string categoryName);
    
    
    Task<int> GetTotalOrderCountAsync();
    
    
    Task<int> GetTodayTotalCompletedOrderCountAsync();
    
    
    Task<decimal> GetTotalCashRevenueAsync();
    
    
    Task<int> GetTotalActiveTableCountAsync();
    
    
    Task<int> GetTotalPassiveTableCountAsync();
    
    
    
    
}