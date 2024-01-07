using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfShoppingCartDal :GenericRepository<ShoppingCart>, IShoppingCartDal
{
    public EfShoppingCartDal(SignalRContext context) : base(context)
    {
    }
    
    
    public int IncrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Quantity += count;
        return shoppingCart.Quantity;
    }
    
    public int DecrementCount(ShoppingCart shoppingCart, int count)
    {
        shoppingCart.Quantity -= count;
        return shoppingCart.Quantity;
    }
    
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        SignalRContext context = new();
        if (tracked)
        {
            IQueryable<ShoppingCart> query = context.ShoppingCarts;

            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }
        else
        {
            IQueryable<ShoppingCart> query = context.ShoppingCarts.AsNoTracking();

            query = query.Where(filter);
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }   
    }

    public IEnumerable<ShoppingCart> GetAllListByFilter(Expression<Func<ShoppingCart, bool>>? filter = null, string? includeProperties = null, string? includeProperties2 = null)
    {
        SignalRContext context = new();
        IQueryable<ShoppingCart> query = context.ShoppingCarts;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            foreach(var includeProp in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
        }
        
        if (includeProperties2 != null)
        {
            foreach(var includeProp2 in includeProperties2.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp2);
            }
        }
        return query.ToList();
    }
    
    public void RemoveRange(IEnumerable<ShoppingCart> entity)
    {
        SignalRContext context = new();
        context.RemoveRange(entity);
        context.SaveChanges();
    }

    public void SaveChanges()
    {
        SignalRContext context = new();
        context.SaveChanges();
    }

    
}