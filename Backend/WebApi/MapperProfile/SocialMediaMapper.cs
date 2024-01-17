using AutoMapper;
using DtoLayer.SocialMediaDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class SocialMediaMapper : Profile
{
    public SocialMediaMapper()
    {
        CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
        CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
    }
    
}