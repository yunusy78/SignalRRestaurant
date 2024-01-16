using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.ShoppingCartDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfShoppingCartDal :GenericRepository<ShoppingCart>, IShoppingCartDal
{
    private readonly SignalRContext _context;
    public EfShoppingCartDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public int IncrementCount(int cartId, int productId)
    {
        
        var shoppingCart = GetFirstOrDefault(x => x.Id == cartId && x.ProductId == productId);
        shoppingCart.Quantity += 1;
        shoppingCart.TotalPrice += shoppingCart.Price;
        _context.ShoppingCarts.Update(shoppingCart);
        _context.SaveChanges();
        return shoppingCart.Quantity;
        
    }
    
    
    public int DecrementCount(int cartId, int productId)
    {
       
        var shoppingCart = GetFirstOrDefault(x => x.Id == cartId && x.ProductId == productId);
        if (shoppingCart.Quantity > 1)
        {
            shoppingCart.Quantity -= 1;
            shoppingCart.TotalPrice -= shoppingCart.Price;
        }
        _context.ShoppingCarts.Update(shoppingCart);
        _context.SaveChanges();
        return shoppingCart.Quantity;
    }
    
    public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter, string? includeProperties = null, bool tracked = true)
    {
        
        if (tracked)
        {
            IQueryable<ShoppingCart> query = _context.ShoppingCarts;

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
            IQueryable<ShoppingCart> query = _context.ShoppingCarts.AsNoTracking();

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
      
        IQueryable<ShoppingCart> query = _context.ShoppingCarts;
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
    
    public void RemoveRange(int cartId, int productId)
    {
       
        var shoppingCart = _context.ShoppingCarts.Where(x => x.Id == cartId && x.ProductId == productId);
        _context.ShoppingCarts.RemoveRange(shoppingCart);
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
       
        _context.SaveChanges();
    }
    
    public async Task<List<ResultShoppingCartWithDiningTableDto>> GetAllListByDiningTableAsync(int diningTableId)
    {
        
        
        var result =await _context.ShoppingCarts.Include(x => x.ResultDiningTableDto)
            .Include(x => x.Product)
            .Where(x => x.DiningTableId == diningTableId)
            .ToListAsync();
        
        List<ResultShoppingCartWithDiningTableDto> resultList = new();
        
        foreach (var item in result)
        {
            ResultShoppingCartWithDiningTableDto dto = new()
            {
                Id = item.Id,
                DiningTableId = item.DiningTableId,
                DiningTableName = item.ResultDiningTableDto.TableName,
                ProductId = item.ProductId,
                ProductName = item.Product.ProductName,
                Quantity = item.Quantity,
                Price = item.Price,
                TotalPrice = item.TotalPrice,
                CreatedDate = item.CreatedDate,
                ImageUrl = item.Product.ImageUrl
            };
            resultList.Add(dto);
        }
        return resultList;
    }
    
    
    public async Task<CreateShoppingCartDto> CreateBasketAsync(CreateShoppingCartDto createBasketDto)
    {
        

        // Aynı üründen sepette var mı kontrol et
        var existingCartItem = await _context.ShoppingCarts
            .FirstOrDefaultAsync(x => x.ProductId == createBasketDto.ProductId && x.DiningTableId == createBasketDto.DiningTableId);

        if (existingCartItem != null)
        {
            // Eğer varsa miktarı artır
            existingCartItem.Quantity += createBasketDto.Quantity;
            existingCartItem.TotalPrice += createBasketDto.TotalPrice;
        }
        else
        {
            // Yoksa yeni bir kayıt ekle
            ShoppingCart shoppingCart = new()
            {
                ProductId = createBasketDto.ProductId,
                Quantity = createBasketDto.Quantity,
                Price = createBasketDto.Price,
                TotalPrice = createBasketDto.TotalPrice,
                DiningTableId = createBasketDto.DiningTableId,
                CreatedDate = createBasketDto.CreatedDate
            };
            await _context.ShoppingCarts.AddAsync(shoppingCart);
        }

        await _context.SaveChangesAsync();
        return createBasketDto;
    }


    
}