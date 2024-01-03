using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfSocialMediaDal:GenericRepository<SocialMedia> , ISocialMediaDal 
{
    public EfSocialMediaDal(SignalRContext context) : base(context)
    {
    }
}