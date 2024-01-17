using AutoMapper;
using DtoLayer.MessageDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class MessageMapper : Profile
{
    public MessageMapper()
    {
        CreateMap<Message, CreateMessageDto>().ReverseMap();
        CreateMap<Message, UpdateMessageDto>().ReverseMap();
        CreateMap<Message, ResultMessageDto>().ReverseMap();
        CreateMap<Message, GetMessageDto>().ReverseMap();
    }
    
    
    
}