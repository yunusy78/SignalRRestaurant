using AutoMapper;
using DtoLayer.ProductDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
        CreateMap<Product, ResultProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
    }
    
}