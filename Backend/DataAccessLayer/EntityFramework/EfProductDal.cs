using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.ProductDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product> , IProductDal
{
    private readonly SignalRContext _context;
    public EfProductDal(SignalRContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<ResultProductWithCategoryDto>> GetListWithCategoryAsync()
    {
        var result = await _context.Products
            .Include(x => x.Category)
            .Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                Status = y.Status,
                CategoryId = y.CategoryId,
                CategoryName = y.Category != null ? y.Category.CategoryName : null
            })
            .ToListAsync();

        return result;
    }
}
