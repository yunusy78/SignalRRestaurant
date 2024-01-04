using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;

namespace BusinessLayer.Abstract;

public interface IReservationService : IGenericService<GetBookingDto>
{
    
    Task<bool> CreateReservationAsync(CreateBookingDto dto);
    Task <bool> UpdateReservationAsync(UpdateBookingDto dto);
    
}