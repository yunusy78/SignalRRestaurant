using AutoMapper;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDetailsDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class OrderDetailsMapper : Profile
{
public OrderDetailsMapper()
    {
        CreateMap<OrderDetails, CreateOrderDetailsDto>().ReverseMap();
        CreateMap<OrderDetails, UpdateOrderDetailsDto>().ReverseMap();
        CreateMap<OrderDetails, ResultOrderDetailsDto>().ReverseMap();
        CreateMap<OrderDetails, GetOrderDetailsDto>().ReverseMap();
    }
    
    
    
    
}