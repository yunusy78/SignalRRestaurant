using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class OrderDetailsManager : IOrderDetailsService
{
    private readonly IOrderDetailsDal _orderDetailsDal;
    
    public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
    {
        _orderDetailsDal = orderDetailsDal;
    }
    
    public async Task<List<OrderDetails>> GetAllAsync()
    {
        return await _orderDetailsDal.GetAllAsync();
    }
    
    public async Task<OrderDetails> GetByIdAsync(int id)
    {
        return await _orderDetailsDal.GetByIdAsync(id);
    }
    
    
    public async Task AddAsync(OrderDetails entity)
    {
        await _orderDetailsDal.AddAsync(entity);
    }
    
    public async Task UpdateAsync(OrderDetails entity)
    {
        await _orderDetailsDal.UpdateAsync(entity);
    }
    
    
    public async Task DeleteAsync(OrderDetails entity)
    {
        await _orderDetailsDal.DeleteAsync(entity);
    }
    
    
}