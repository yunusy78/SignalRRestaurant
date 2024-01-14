using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using DtoLayer.DiningTableDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class DiningTableManager : IDiningTableService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
  
    public DiningTableManager(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.DiningTable.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<ResultDiningTableDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.DiningTable.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var result = JsonConvert.DeserializeObject<List<ResultDiningTableDto>>(await response.Content.ReadAsStringAsync());
        return result;
    }

    public async Task<ResultDiningTableDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.DiningTable.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = JsonConvert.DeserializeObject<ResultDiningTableDto>(await response.Content.ReadAsStringAsync());
        return result;
        
    }

    public Task<List<ResultDiningTableDto>> GetListByFilterAsync(Expression<Func<ResultDiningTableDto, bool>> filter)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> AddAsync(CreateDiningTableDto entity)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var stringContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.DiningTable.Path}", stringContent);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
    
    public async Task<bool> UpdateAsync(UpdateDiningTableDto entity)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var stringContent = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.DiningTable.Path}", stringContent);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
}