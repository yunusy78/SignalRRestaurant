using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    
    
    public FeatureManager(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings =  _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return  false;
    }

    public async Task<List<ResultFeatureDto>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<ResultFeatureDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public async Task<ResultFeatureDto> GetByIdAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<ResultFeatureDto>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}/{id}");
        if (response == null)
        {
            return null;
        }
        return response;
        
    }

    public async Task<List<ResultFeatureDto>> GetListByFilterAsync(Expression<Func<ResultFeatureDto, bool>> filter)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<ResultFeatureDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}");
        return response;
        
    }

    public async Task<bool> AddAsync(CreateFeatureDto entity)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
    }

    public async Task<bool> UpdateAsync(UpdateFeatureDto entity)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}