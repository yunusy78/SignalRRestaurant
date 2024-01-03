using AutoMapper;
using DtoLayer.TestimonialDtos;
using EntityLayer.Concrete;

namespace WebApi.Mapper;

public class TestimonialMapper : Profile
{
    public TestimonialMapper()
    {
        CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
        CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
    }
    
    
    
}