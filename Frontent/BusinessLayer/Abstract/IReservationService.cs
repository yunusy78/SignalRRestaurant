using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;

namespace BusinessLayer.Abstract;

public interface IReservationService : IGenericService<GetReservationDto>
{
    
    Task<bool> CreateReservationAsync(CreateReservationDto dto);
    Task <bool> UpdateReservationAsync(UpdateReservationDto dto);
    
}