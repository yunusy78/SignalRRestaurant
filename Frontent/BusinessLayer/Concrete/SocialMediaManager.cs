using System.Linq.Expressions;
using System.Text;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.SocialMediaDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class SocialMediaManager : ISocialMediaService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public SocialMediaManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
    }

    public async Task<List<ResultSocialMediaDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}");
        if (response.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(await response.Content.ReadAsStringAsync());
            return result;
        }
        
        return null;
    }

    public async Task<ResultSocialMediaDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<ResultSocialMediaDto>(await response.Content.ReadAsStringAsync());
            return result;
        }
        
        return null;
    }

    public Task<List<ResultSocialMediaDto>> GetListByFilterAsync(Expression<Func<ResultSocialMediaDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> AddAsync(CreateSocialMediaDto socialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(socialMediaDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}", data);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
        
    }

    public async Task<bool> UpdateAsync(UpdateSocialMediaDto socialMediaDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var json = JsonConvert.SerializeObject(socialMediaDto);
        var data = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PutAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.SocialMedia.Path}", data);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
    }
}