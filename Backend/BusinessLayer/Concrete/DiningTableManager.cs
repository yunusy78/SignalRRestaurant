using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.DiningTableDtos;
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

    public async Task AddAsync(DiningTable resultDiningTableDto)
    {
        await _diningTableDal.AddAsync(resultDiningTableDto);
    }

    public async Task UpdateAsync(DiningTable resultDiningTableDto)
    {
        await _diningTableDal.UpdateAsync(resultDiningTableDto);
    }

    public async Task DeleteAsync(DiningTable resultDiningTableDto)
    {
        await _diningTableDal.DeleteAsync(resultDiningTableDto);
    }
}
