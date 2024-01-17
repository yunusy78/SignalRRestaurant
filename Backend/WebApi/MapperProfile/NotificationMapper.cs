using AutoMapper;
using DtoLayer.NotificationDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class NotificationMapper : Profile
{
    public NotificationMapper()
    {
        CreateMap<Notification, CreateNotificationDto>().ReverseMap();
        CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
        CreateMap<Notification, ResultNotificationDto>().ReverseMap();
        CreateMap<Notification, GetNotificationDto>().ReverseMap();
    }
    
    
    
}