using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class DiningTableManager : IDiningTableService
{
    private readonly IDiningTableDal _diningTableDal;
    
    public DiningTableManager(IDiningTableDal diningTableDal)
    {
        _diningTableDal = diningTableDal;
    }
    
    public async Task<List<DiningTable>> GetAllAsync()
    {
        var result = await _diningTableDal.GetAllAsync();
        return result;
    }

    public async Task<DiningTable> GetByIdAsync(int id)
    {
        var result = await _diningTableDal.GetByIdAsync(id);
        return result;
    }

    public async Task AddAsync(DiningTable diningTable)
    {
        await _diningTableDal.AddAsync(diningTable);
    }

    public async Task UpdateAsync(DiningTable diningTable)
    {
        await _diningTableDal.UpdateAsync(diningTable);
    }

    public async Task DeleteAsync(DiningTable diningTable)
    {
        await _diningTableDal.DeleteAsync(diningTable);
    }
}
