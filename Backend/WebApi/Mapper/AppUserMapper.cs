using AutoMapper;
using DtoLayer.AboutDtos;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class DiningTableMapper : Profile
{
    public DiningTableMapper()
    {
        CreateMap<DiningTable, CreateDiningTableDto>().ReverseMap();
        CreateMap<DiningTable, UpdateDiningTableDto>().ReverseMap();
        CreateMap<DiningTable, ResultDiningTableDto>().ReverseMap();
        CreateMap<DiningTable, GetDiningTableDto>().ReverseMap();
    }
    
    
    
}