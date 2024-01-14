using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class MessageManager : IMessageService
{
    private readonly IMessageDal _messageDal;
    
    public MessageManager(IMessageDal messageDal)
    {
        _messageDal = messageDal;
    }
    
    public async Task<List<Message>> GetAllAsync()
    {
        return await _messageDal.GetAllAsync();
    }
    
    public async Task<Message> GetByIdAsync(int id)
    {
        return await _messageDal.GetByIdAsync(id);
    }
    
    public async Task AddAsync(Message entity)
    {
        await _messageDal.AddAsync(entity);
    }
    
    public async Task UpdateAsync(Message entity)
    {
        await _messageDal.UpdateAsync(entity);
    }
    
    public async Task DeleteAsync(Message entity)
    {
        await _messageDal.DeleteAsync(entity);
    }
    
    
    
}