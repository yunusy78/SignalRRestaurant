using AutoMapper;
using DtoLayer.FeatureDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class FeatureMapper : Profile
{
    public FeatureMapper()
    {
        CreateMap<Feature, CreateFeatureDto>().ReverseMap();
        CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
        CreateMap<Feature, ResultFeatureDto>().ReverseMap();
        CreateMap<Feature, GetFeatureDto>().ReverseMap();
    }
    
    
    
}