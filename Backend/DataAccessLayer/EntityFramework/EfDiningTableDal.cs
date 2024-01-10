using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfDiningTableDal : GenericRepository<DiningTable>, IDiningTableDal
{
    public EfDiningTableDal(SignalRContext context) : base(context)
    {
    }
}