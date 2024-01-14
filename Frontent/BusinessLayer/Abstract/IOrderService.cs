using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDtos;

namespace BusinessLayer.Abstract;

public interface IOrderService : IGenericService<GetOrderDto>
{
    
    Task<bool> CreateAsync(CreateOrderDto dto);
    Task <bool> UpdateAsync(UpdateOrderDto dto);
    
}