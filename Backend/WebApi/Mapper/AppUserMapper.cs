using AutoMapper;
using DtoLayer.AboutDtos;
using DtoLayer.AppUserDtos;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class AppUserMapper : Profile
{
    public AppUserMapper()
    {
        CreateMap<AppUser, ApplicationUserDto>().ReverseMap();
        CreateMap<AppUser, ForgotPasswordDto>().ReverseMap();
        CreateMap<AppUser, ResetPasswordDto>().ReverseMap();
        CreateMap<AppRole, UserRoleDto>().ReverseMap();
    }
    
    
    
}