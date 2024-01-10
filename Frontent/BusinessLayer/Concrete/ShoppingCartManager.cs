using System.Linq.Expressions;
using System.Text;
using BusinessLayer.Abstract;
using DtoLayer.ShoppingCartDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class ShoppingCartManager : IShoppingCartService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public ShoppingCartManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    
    public Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart}/{id}");
        
        if (!responseMessage.Result.IsSuccessStatusCode)
        {
            throw new Exception("Error while calling service api.");
        }
        
        var result = JsonConvert.DeserializeObject<bool>(responseMessage.Result.Content.ReadAsStringAsync().Result);
        return Task.FromResult(result);
        
    }

    public Task<List<ResultShoppingCart>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultShoppingCart> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultShoppingCart>> GetListByFilterAsync(Expression<Func<ResultShoppingCart, bool>> filter)
    {
        throw new NotImplementedException();
    }
  
    public Task<bool> IncrementCount(int cartId, int productId)  
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart.Path}/IncrementCount?cartId={cartId}&productId={productId}");
        
        if (!responseMessage.Result.IsSuccessStatusCode)
        {
            throw new Exception("Error while calling service api.");
        }
        
        return Task.FromResult(true);
    }

    public Task<bool> DecrementCount(int cartId, int productId)  
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart.Path}/DecrementCount?cartId={cartId}&productId={productId}");
        
        if (!responseMessage.Result.IsSuccessStatusCode)
        {
            throw new Exception("Error while calling service api.");
        }
        
        return Task.FromResult(true);
        
    }

    public async Task<List<ResultShoppingCartWithDiningTableDto>> GetAllListByDiningTableAsync(int diningTableId)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var responseMessage = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart.Path}/GetAllListByDiningTableAsync?diningTableId={diningTableId}");
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception("Error while calling service api.");
        }
        
        var result = JsonConvert.DeserializeObject<List<ResultShoppingCartWithDiningTableDto>>(responseMessage.Content.ReadAsStringAsync().Result);
        return result;
        
    }
    
    
    
public async Task<bool> CreateBasketAsync(CreateShoppingCartDto createBasketDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(createBasketDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var responseMessage = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart.Path}/CreateBasketAsync", data);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception("Error while calling service api.");
        }
        return true;
        
    }

public Task<bool> RemoveRange(int cartId, int productId)
{
    var client = _httpClientFactory.CreateClient();
    var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
    var responseMessage = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.ShoppingCart.Path}/RemoveRange?cartId={cartId}&productId={productId}");
    
    if (!responseMessage.Result.IsSuccessStatusCode)
    {
        throw new Exception("Error while calling service api.");
    }
    
    return Task.FromResult(true);
}
}