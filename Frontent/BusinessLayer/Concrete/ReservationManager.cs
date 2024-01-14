using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class ReservationManager : IReservationService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    
    public ReservationManager(IHttpClientFactory httpClientFactory, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
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
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false;
    }

    public async Task<List<GetReservationDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GetReservationDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<GetReservationDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GetReservationDto>(jsonContent.Result);
            return result!;
        }
        return null;
    }

    public async Task<List<GetReservationDto>> GetListByFilterAsync(Expression<Func<GetReservationDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}/{filter}");
        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var result= JsonConvert.DeserializeObject<List<GetReservationDto>>(jsonContent);
            return result!;
        }
        return null;
    }

    public async Task<bool> CreateReservationAsync(CreateReservationDto dto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

        // HTTP isteği oluştur
        var request = new HttpRequestMessage(HttpMethod.Post, $"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}");

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


    public async Task<bool> UpdateReservationAsync(UpdateReservationDto dto)
    {
        var jwtToken = _httpContextAccessor.HttpContext!.Request.Cookies["JwtToken"];
        var client = _httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Reservation.Path}", dto);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        
        return false;
        


    }
    
}