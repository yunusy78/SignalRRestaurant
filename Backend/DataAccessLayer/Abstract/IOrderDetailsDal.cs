using DtoLayer.OrderDetailsDtos;
using DtoLayer.OrderDtos;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IOrderDetailsDal : IGenericDal<OrderDetails>
{
    Task<List<ResultOrderDetailsDto>> GetOrderDetailsByOrderWithProductName();
    
}