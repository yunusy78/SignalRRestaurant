using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class OrderManager : IOrderService
{
    private readonly IOrderDal _orderDal;
    
    public OrderManager(IOrderDal orderDal)
    {
        _orderDal = orderDal;
    }
    public async Task<List<Order>> GetAllAsync()
    {
        var orders = await _orderDal.GetAllAsync();
        return orders;
    }

    public async Task<Order> GetByIdAsync(int id)
    {
        var order = await _orderDal.GetByIdAsync(id);
        return order;
        
    }

    public async Task AddAsync(Order entity)
    {
        await _orderDal.AddAsync(entity);
    }

    public async Task UpdateAsync(Order entity)
    {
        await _orderDal.UpdateAsync(entity);
        
    }

    public async Task DeleteAsync(Order entity)
    {
        await _orderDal.DeleteAsync(entity);
        
    }
}