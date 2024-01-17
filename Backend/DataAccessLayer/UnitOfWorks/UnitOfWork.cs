using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.UnitOfWorks;

public class UnitOfWork : IUnitOfWorks
{
    private readonly SignalRContext _context;
    
    public UnitOfWork(SignalRContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}