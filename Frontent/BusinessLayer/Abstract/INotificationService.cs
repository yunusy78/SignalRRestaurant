using DtoLayer.ContactDtos;
using DtoLayer.MessageDtos;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace BusinessLayer.Abstract;

public interface IMessageService : IGenericService<ResultMessageDto>
{
    Task<bool> AddAsync(CreateMessageDto dto);
    Task<bool> UpdateAsync(UpdateMessageDto dto);
}