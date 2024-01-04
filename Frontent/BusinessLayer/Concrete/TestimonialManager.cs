using System.Linq.Expressions;
using System.Net.Http.Json;
using BusinessLayer;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDtos;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
    public TestimonialManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.DeleteAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<List<ResultTestimonialDto>> GetAllAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var TestimonialDtos = await response.Content.ReadFromJsonAsync<List<ResultTestimonialDto>>();
        return TestimonialDtos!;
    }

    public async Task<ResultTestimonialDto> GetByIdAsync(int id)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var testimonialDto = await response.Content.ReadFromJsonAsync<ResultTestimonialDto>();
        return testimonialDto!;
    }

    public async Task<List<ResultTestimonialDto>> GetListByFilterAsync(Expression<Func<ResultTestimonialDto, bool>> filter)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.GetAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        var testimonialDtos = await response.Content.ReadFromJsonAsync<List<ResultTestimonialDto>>();
        return testimonialDtos!;


    }

    public async Task<bool> AddAsync(CreateTestimonialDto testimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PostAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}", testimonialDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }

    public async Task<bool> UpdateAsync(UpdateTestimonialDto testimonialDto)
    {
        var client = _httpClientFactory.CreateClient();
        var serviceApiSettings = _configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        var response = await client.PutAsJsonAsync($"{serviceApiSettings!.BaseUri}/{serviceApiSettings.Testimonial.Path}", testimonialDto);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
        
    }
}