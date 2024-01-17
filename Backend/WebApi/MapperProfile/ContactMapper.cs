using AutoMapper;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class ContactMapper : Profile
{
    public ContactMapper()
    {
        CreateMap<Contact, CreateContactDto>().ReverseMap();
        CreateMap<Contact, UpdateContactDto>().ReverseMap();
        CreateMap<Contact, ResultContactDto>().ReverseMap();
        CreateMap<Contact, GetContactDto>().ReverseMap();
    }
    
}