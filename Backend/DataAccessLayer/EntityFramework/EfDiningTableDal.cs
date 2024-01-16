using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDiningTableDal : GenericRepository<DiningTable>, IDiningTableDal
{
    private readonly SignalRContext _context;
    public EfDiningTableDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<int> GetTotalActiveTableCountAsync()
    {
        
        return await _context.DiningTables.CountAsync(x => x.Status);
    }

    public async Task<int> GetTotalPassiveTableCountAsync()
    {
        
        return await _context.DiningTables.CountAsync(x => !x.Status);
    }
    
    public async Task<List<DiningTable>> GetDiningTablesByStatusAsync()
    {
        
        return await _context.DiningTables.Where(x => x.Status).ToListAsync();
    }
}