using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Exceptions;
using DataAccessLayer.Abstract;
using DtoLayer.ProductDtos;
using EntityLayer.Concrete;
using Microsoft.Extensions.Caching.Memory;

namespace CachingLayer;

public class ProductServiceWithCaching : IProductService
{
    private const string CacheProductKey="ProductList";
    private readonly IProductDal _productDal;
    private readonly IMemoryCache _memoryCache;
    private readonly IMapper _mapper;
    
    public ProductServiceWithCaching(IProductDal productDal, IMemoryCache memoryCache, IMapper mapper)
    {
        _productDal = productDal;
        _memoryCache = memoryCache;
        _mapper = mapper;
        
        if (!_memoryCache.TryGetValue(CacheProductKey, out _))
        {
           _memoryCache.Set(CacheProductKey, _productDal.GetListWithCategoryAsync().Result);
        }
    }
    public Task<List<Product>> GetAllAsync()
    {
        var result = _mapper.Map<List<Product>>(_memoryCache.Get<List<ResultProductWithCategoryDto>>(CacheProductKey)!);
        return Task.FromResult(result);
    }

    public  Task<Product> GetByIdAsync(int id)
    {
        var product =_mapper.Map<List<Product>>(_memoryCache.Get<List<ResultProductWithCategoryDto>>(CacheProductKey)!)
            .FirstOrDefault(x => x.ProductId == id);
        if (product==null)
        {
            throw new NotFoundException("Product not found");
        }
        return Task.FromResult(product);
    }

    public async Task AddAsync(Product entity)
    {
        await _productDal.AddAsync(entity);
        await CashAllProduct();
    }

    public async Task UpdateAsync(Product entity)
    {
        await _productDal.UpdateAsync(entity);
        await CashAllProduct();
        
    }

    public async Task DeleteAsync(Product entity)
    {
        await _productDal.DeleteAsync(entity);
        await CashAllProduct();
    }

    public Task<List<ResultProductWithCategoryDto>> GetListWithCategoryAsync()
    {
        var result = _memoryCache.Get<List<ResultProductWithCategoryDto>>(CacheProductKey)!;
        return Task.FromResult(result);
    }
    
    public async Task CashAllProduct()
    {
        var result = await _productDal.GetAllAsync();
        _memoryCache.Set(CacheProductKey, result,TimeSpan.FromMinutes(1));
    }
}