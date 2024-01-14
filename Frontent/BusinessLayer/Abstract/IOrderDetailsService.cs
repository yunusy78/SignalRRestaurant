using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDetailsDtos;
using DtoLayer.OrderDtos;

namespace BusinessLayer.Abstract;

public interface IOrderDetailsService : IGenericService<GetOrderDetailsDto>
{
    
    Task<bool> CreateAsync(CreateOrderDetailsDto dto);
    Task <bool> UpdateAsync(UpdateOrderDetailsDto dto);
    
    Task<List<ResultOrderDetailsDto>> GetOrderDetailsByOrderWithProductName();
    
}