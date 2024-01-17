using AutoMapper;
using DtoLayer.AboutDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class AboutMapper : Profile
{
    public AboutMapper()
    {
        CreateMap<About, CreateAboutDto>().ReverseMap();
        CreateMap<About, UpdateAboutDto>().ReverseMap();
        CreateMap<About, ResultAboutDto>().ReverseMap();
        CreateMap<About, GetAboutDto>().ReverseMap();
    }
    
}