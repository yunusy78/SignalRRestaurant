using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class OrderManager : IOrderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    
    public OrderManager(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<List<GetOrderDto>> GetAllAsync()
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetOrderDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<GetOrderDto> GetByIdAsync(int id)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetOrderDto>(jsonContent.Result);
            return result!;
        }
        return null;
    }

    public async Task<List<GetOrderDto>> GetListByFilterAsync(Expression<Func<GetOrderDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}/{filter}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result= JsonConvert.DeserializeObject<List<GetOrderDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<bool> CreateAsync(CreateOrderDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        // HTTP isteği oluştur
        var request = new HttpRequestMessage(HttpMethod.Post, $"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}");

        // İsteği JSON içeriğiyle birlikte gönder
        request.Content = JsonContent.Create(dto);

        // İsteği gönder ve yanıtı al
        var response = await client.SendAsync(request);

        // Yanıtı işle
        if (response.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }


    public async Task<bool> UpdateAsync(UpdateOrderDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Order.Path}", dto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;

    }
    
}