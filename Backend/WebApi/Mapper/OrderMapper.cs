using AutoMapper;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class OrderMapper : Profile
{
public OrderMapper()
    {
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();
        CreateMap<Order, ResultOrderDto>().ReverseMap();
        CreateMap<Order, GetOrderDto>().ReverseMap();
    }
    
    
    
    
}