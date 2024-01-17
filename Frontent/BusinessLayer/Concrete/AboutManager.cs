using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using DtoLayer.CustomResponseDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public AboutManager(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        
        var jwtToken=_httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<ResultAboutDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var result = await response.Content.ReadFromJsonAsync<CustomResponseDto<List<ResultAboutDto>>>();
        return result!.Data;
    }

    public async Task<ResultAboutDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var AboutDto = await response.Content.ReadFromJsonAsync<ResultAboutDto>();
        return AboutDto!;
    }

    public async Task<List<ResultAboutDto>> GetListByFilterAsync(Expression<Func<ResultAboutDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var AboutDtos = await response.Content.ReadFromJsonAsync<List<ResultAboutDto>>();
        return AboutDtos!;


    }

    public async Task<bool> AddAsync(CreateAboutDto aboutDto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}", aboutDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(UpdateAboutDto aboutDto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.About.Path}", aboutDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}