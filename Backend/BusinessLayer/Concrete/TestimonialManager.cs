using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;
    
    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal = testimonialDal;
    }
    
    
    public async Task<List<Testimonial>> GetAllAsync()
    {
       return await _testimonialDal.GetAllAsync();
        
    }
    
    public async Task<Testimonial> GetByIdAsync(int id)
    {
        return await _testimonialDal.GetByIdAsync(id);
    }
    
    
    public async Task AddAsync(Testimonial entity)
    {
        await _testimonialDal.AddAsync(entity);
        
    }
    
    
    public async Task UpdateAsync(Testimonial entity)
    {
        await _testimonialDal.UpdateAsync(entity);
        
    }
    
    
    public async Task DeleteAsync(Testimonial entity)
    {
        await _testimonialDal.DeleteAsync(entity);
    }
    

    
    
    
}