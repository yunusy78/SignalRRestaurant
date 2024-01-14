using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using DtoLayer.OrderDetailsDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class OrderDetailsManager : IOrderDetailsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    
    public OrderDetailsManager(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<List<GetOrderDetailsDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetOrderDetailsDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<GetOrderDetailsDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetOrderDetailsDto>(jsonContent.Result);
            return result!;
        }
        return null;
    }

    public async Task<List<GetOrderDetailsDto>> GetListByFilterAsync(Expression<Func<GetOrderDetailsDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}/{filter}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result= JsonConvert.DeserializeObject<List<GetOrderDetailsDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<bool> CreateAsync(CreateOrderDetailsDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        // HTTP isteği oluştur
        var request = new HttpRequestMessage(HttpMethod.Post, $"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}");

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


    public async Task<bool> UpdateAsync(UpdateOrderDetailsDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}", dto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;

    }
    
    public async Task<List<ResultOrderDetailsDto>> GetOrderDetailsByOrderWithProductName()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.OrderDetails.Path}/GetOrderDetailsByOrderWithProductName");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ResultOrderDetailsDto>>(jsonContent);
            return result!;
        }
        return null;
    }
    
}