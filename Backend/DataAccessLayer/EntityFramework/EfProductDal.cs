using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using DtoLayer.ProductDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product> , IProductDal
{
    public EfProductDal(SignalRContext context) : base(context)
    {
    }

    public async Task<List<ResultProductWithCategoryDto>> GetListWithCategoryAsync()
    {
        var context = new SignalRContext();
        var result = await context.Products
            .Include(x => x.Category).Select(y=>new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductId = y.ProductId,
                ProductName = y.ProductName,
                Status = y.Status,
                CategoryId = y.CategoryId,
                CategoryName = y.Category.CategoryName
            })
            .ToListAsync();
        return result;
    }

}
