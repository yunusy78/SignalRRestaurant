using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer.Abstract;
using DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class MessageManager :IMessageService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;


   
    public MessageManager(IHttpClientFactory clientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Message.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return  false;
    }

    public async Task<List<ResultMessageDto>> GetAllAsync()
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<List<ResultMessageDto>>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Message.Path}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public async Task<ResultMessageDto> GetByIdAsync(int id)
    {
        var client = _clientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetFromJsonAsync<ResultMessageDto>($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Message.Path}/{id}");
        if (response == null)
        {
            return null;
        }
        return response;
    }

    public Task<List<ResultMessageDto>> GetListByFilterAsync(Expression<Func<ResultMessageDto, bool>> filter)
    {
        throw new NotImplementedException();
    }
    
    public async Task<bool> AddAsync(CreateMessageDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Message.Path}", dto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        
        return true;
    }
    
    public async Task<bool> UpdateAsync(UpdateMessageDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings =  _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Message.Path}", dto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        return true;
    }
    
}