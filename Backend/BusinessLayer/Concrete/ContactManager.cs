using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactManager : IContactService
{
    private readonly IContactDal _contactDal;

    public ContactManager(IContactDal contactDal)
    {
        _contactDal = contactDal;
    }
    
    
    public async Task<List<Contact>> GetAllAsync()
    {
        return await _contactDal.GetAllAsync();
    }
    
    public async Task<Contact> GetByIdAsync(int id)
    {
        return await _contactDal.GetByIdAsync(id);
    }
    
    public async Task AddAsync(Contact entity)
    {
        await _contactDal.AddAsync(entity);
    }
    
    public async Task UpdateAsync(Contact entity)
    {
        await _contactDal.UpdateAsync(entity);
    }
    
    
    public async Task DeleteAsync(Contact entity)
    {
        await _contactDal.DeleteAsync(entity);
    }
    
    
    
    
}