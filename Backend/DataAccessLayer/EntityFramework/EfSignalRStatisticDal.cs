using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfSignalRStatisticDal : ISignalRStatisticDal
{
    private readonly SignalRContext _context;

    public EfSignalRStatisticDal(SignalRContext context)
    {
        _context = context;
    }

    public async Task<int> GetTotalProductCountAsync()
    {
        return await _context.Products.CountAsync();
    }

    public async Task<int> GetTotalCategoryCountAsync()
    {
        return await _context.Categories.CountAsync();
    }
    
    public async Task<int> GetTotalActiveBookingCountAsync()
    {
        return await _context.Bookings.CountAsync(x=>x.IsConfirmed);
    }
    
    
    public async Task<int> GetTotalPassiveBookingCountAsync()
    {
        return await _context.Bookings.CountAsync(x=>!x.IsConfirmed);
    }
    
    
    public async Task<decimal> GetAveragePriceAsync()
    {
        return await _context.Products.AverageAsync(x=>x.Price);
    }
    
    
    
    public async Task<string> GetCheapestProductAsync()
    {
        var cheapestProduct = await _context.Products.MinAsync(x => x.Price);
        var cheapestProductString = await _context
            .Products.Where(x => x.Price == cheapestProduct)
            .Select(x => x.ProductName)
            .FirstOrDefaultAsync();
        return cheapestProductString!;
    }


    public async Task<string> GetExpensiveProductAsync()
    {
        var expensiveProduct = await _context.Products.MaxAsync(x => x.Price);
        var expensiveProductString = await _context.Products.Where(x => x.Price == expensiveProduct)
            .Select(x => x.ProductName)
            .FirstOrDefaultAsync();
        return expensiveProductString!;
    }
    
    public async Task<int> GetTotalProductCountByCategoryAsync(int categoryId)
    {
        return await _context.Products.CountAsync(x => x.CategoryId == categoryId);
    }
    
    
    public async Task<string> GetTotalProductCountByCategoryNameAsync(string categoryName)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == categoryName);
        var result = await _context.Products.CountAsync(x => category != null && x.CategoryId == category.CategoryId);
        return result.ToString();
    }
    
    
    public async Task<int> GetTotalOrderCountAsync()
    {
        return await _context.Orders.CountAsync();
    }
    
    
    public async Task<int> GetTodayTotalCompletedOrderCountAsync()
    {
        return await _context.Orders.CountAsync(x => x.OrderDate == DateTime.Today && x.Status);
    }
    
    
    public async Task<decimal> GetTotalCashRevenueAsync()
    {
        return await _context.CashTransactions.SumAsync(x => x.Amount);
    }
    
    
    public async Task<int> GetTotalActiveTableCountAsync()
    {
        return await _context.DiningTables.CountAsync(x => x.Status);
    }
    
    
    public async Task<int> GetTotalPassiveTableCountAsync()
    {
        return await _context.DiningTables.CountAsync(x => !x.Status);
    }
    
    
    


    
    
}