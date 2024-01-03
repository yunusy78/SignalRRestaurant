using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;

public class GenericRepository<T> : IGenericDal<T> where T : class, new()
{
    private readonly SignalRContext _context;
    
    public GenericRepository(SignalRContext context)
    {
        _context = context;
    }


    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
        
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return (await _context.Set<T>().FindAsync(id))!;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}