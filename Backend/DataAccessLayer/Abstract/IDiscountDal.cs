﻿using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IDiscountDal : IGenericDal<Discount>
{
    Task<int> CheckDiscountCodeAsync(string code);
    
}