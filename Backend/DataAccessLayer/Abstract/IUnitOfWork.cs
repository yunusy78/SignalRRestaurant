namespace DataAccessLayer.Abstract;

public interface IUnitOfWorks
{
    Task CommitAsync();
    void Commit();
    
}