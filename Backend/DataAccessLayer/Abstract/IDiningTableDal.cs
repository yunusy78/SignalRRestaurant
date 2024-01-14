using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IDiningTableDal : IGenericDal<DiningTable>
{
    Task<int> GetTotalActiveTableCountAsync();
    
    Task<int> GetTotalPassiveTableCountAsync();
    
    
    Task<List<DiningTable>> GetDiningTablesByStatusAsync();
}