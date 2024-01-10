using System.Linq.Expressions;
using BusinessLayer.Abstract;
using DtoLayer.DiningTableDtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete;

public class DiningTableManager : IDiningTableService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    
  public DiningTableManager(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }
    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
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

    public Task<ResultDiningTableDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultDiningTableDto>> GetListByFilterAsync(Expression<Func<ResultDiningTableDto, bool>> filter)
    {
        throw new NotImplementedException();
    }
}