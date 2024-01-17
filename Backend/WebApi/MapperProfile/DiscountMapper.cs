using AutoMapper;
using DtoLayer.DiscountDtos;
using DtoLayer.FeatureDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class DiscountMapper : Profile
{
    public DiscountMapper()
    {
        CreateMap<Discount, CreateDiscountDto>().ReverseMap();
        CreateMap<Discount, UpdateDiscountDto>().ReverseMap();
        CreateMap<Discount, ResultDiscountDto>().ReverseMap();
        CreateMap<Discount, GetDiscountDto>().ReverseMap();
    }
    
    
    
    
}