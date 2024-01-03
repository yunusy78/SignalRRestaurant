using AutoMapper;
using DtoLayer.BookingDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class BookingMapper : Profile
{
public BookingMapper()
    {
        CreateMap<Booking, CreateBookingDto>().ReverseMap();
        CreateMap<Booking, UpdateBookingDto>().ReverseMap();
        CreateMap<Booking, ResultBookingDto>().ReverseMap();
        CreateMap<Booking, GetBookingDto>().ReverseMap();
    }
    
    
    
    
}