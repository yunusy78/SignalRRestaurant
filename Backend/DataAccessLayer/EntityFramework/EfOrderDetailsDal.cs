using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.OrderDetailsDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfOrderDetailsDal : GenericRepository<OrderDetails>, IOrderDetailsDal
{
    private readonly SignalRContext _context;
    public EfOrderDetailsDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<List<ResultOrderDetailsDto>> GetOrderDetailsByOrderWithProductName()
    {
        
        var result = await _context.OrderDetails
            .Include(x => x.Product)
            .Include(x => x.Order)
            .Select(x => new ResultOrderDetailsDto
            {
                OrderDetailsId = x.OrderDetailsId,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                ProductName = x.Product.ProductName,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                TotalPrice = x.TotalPrice,
                Status = x.Status
            }).ToListAsync();
        return result;
    }
}