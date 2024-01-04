using BusinessLayer.Abstract;
using DtoLayer.ContactDtos;

namespace BusinessLayer.Abstract;

public interface IContactService : IGenericService<ResultContactDto>
{
    Task<bool> AddAsync(CreateContactDto contactDto);
    Task<bool> UpdateAsync(UpdateContactDto contactDto);
    
}