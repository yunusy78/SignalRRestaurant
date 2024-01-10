using System.Linq.Expressions;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.FeatureDtos;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class FeatureManager : IFeatureService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    
    
    public FeatureManager(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }
    
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _clientFactory.CreateClient();
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
        var client = _clientFactory.CreateClient();
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
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Feature.Path}", entity);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}