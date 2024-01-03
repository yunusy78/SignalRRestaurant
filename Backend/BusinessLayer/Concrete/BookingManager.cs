using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;
    
    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }
    
    
    public async Task<List<Booking>> GetAllAsync()
    {
       return await _bookingDal.GetAllAsync();
        
    }
    
    public async Task<Booking> GetByIdAsync(int id)
    {
        return await _bookingDal.GetByIdAsync(id);
    }
    
    public async Task AddAsync(Booking entity)
    {
        await _bookingDal.AddAsync(entity);
        
    }
    
    public async Task UpdateAsync(Booking entity)
    {
        await _bookingDal.UpdateAsync(entity);
        
    }
    
    
    public async Task DeleteAsync(Booking entity)
    {
        await _bookingDal.DeleteAsync(entity);
    }
    
    
    
    
    
    
}