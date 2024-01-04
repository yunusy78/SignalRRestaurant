

using DtoLayer.TestimonialDtos;

namespace BusinessLayer.Abstract;

public interface ITestimonialService : IGenericService<ResultTestimonialDto>
{
    
    Task<bool> AddAsync(CreateTestimonialDto testimonialDto);
    Task<bool> UpdateAsync(UpdateTestimonialDto testimonialDto);
    
}