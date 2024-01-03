﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfTestimonialDal:GenericRepository<Testimonial> , ITestimonialDal
{
    public EfTestimonialDal(SignalRContext context) : base(context)
    {
    }
}
