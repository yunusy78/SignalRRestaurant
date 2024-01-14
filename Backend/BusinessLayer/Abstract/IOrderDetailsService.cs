using DtoLayer.OrderDetailsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IOrderDetailsService  : IGenericService<OrderDetails>
{
    
    Task<List<ResultOrderDetailsDto>> GetOrderDetailsByOrderWithProductName();
    
    
    
}