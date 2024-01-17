using AutoMapper;
using DtoLayer.CategoryDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class CategoryMapper : Profile
{
    public CategoryMapper()
    {
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        CreateMap<Category, ResultCategoryDto>().ReverseMap();
        CreateMap<Category, GetCategoryDto>().ReverseMap();
    }
    
}