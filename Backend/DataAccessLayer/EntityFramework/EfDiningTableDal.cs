using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDiningTableDal : GenericRepository<DiningTable>, IDiningTableDal
{
    public EfDiningTableDal(SignalRContext context) : base(context)
    {
    }
    
    public async Task<int> GetTotalActiveTableCountAsync()
    {
        var context = new SignalRContext();
        return await context.DiningTables.CountAsync(x => x.Status);
    }

    public async Task<int> GetTotalPassiveTableCountAsync()
    {
        var context = new SignalRContext();
        return await context.DiningTables.CountAsync(x => !x.Status);
    }
    
    public async Task<List<DiningTable>> GetDiningTablesByStatusAsync()
    {
        var context = new SignalRContext();
        return await context.DiningTables.Where(x => x.Status).ToListAsync();
    }
}