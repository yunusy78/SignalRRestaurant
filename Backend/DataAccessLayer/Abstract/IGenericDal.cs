namespace DataAccessLayer.Abstract;

public interface IGenericDal <T> where T : class, new()
{
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    
}