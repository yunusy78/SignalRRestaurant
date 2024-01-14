using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer.Abstract;
using DtoLayer.NotificationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class NotificationManager :INotificationService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;


   
    public NotificationManager(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return  false;
    }

    public async Task<List<ResultNotificationDto>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<ResultNotificationDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public async Task<ResultNotificationDto> GetByIdAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<ResultNotificationDto>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}/{id}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public Task<List<ResultNotificationDto>> GetListByFilterAsync(Expression<Func<ResultNotificationDto, bool>> filter)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> AddAsync(CreateNotificationDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}", dto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
    }
    
    public async Task<bool> UpdateAsync(UpdateNotificationDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings =  _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}", dto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return true;
    }

    public int GetNotificationCountByStatus()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Notification.Path}/GetNotificationCountByStatus").Result;
        if (response.IsSuccessStatusCode)
        {
            var result = response.Content.ReadAsStringAsync().Result;
            return Convert.ToInt32(result);
        }
        return 0;
        
    }
}