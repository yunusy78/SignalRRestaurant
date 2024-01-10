using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRStatisticController : ControllerBase
    {
        private readonly ISignalRStatisticService _signalRStatisticService;
        private readonly IMapper _mapper;
        
        
        public SignalRStatisticController(ISignalRStatisticService signalRStatisticService, IMapper mapper)
        {
            _signalRStatisticService = signalRStatisticService;
            _mapper = mapper;
        }
        
       
        
        [HttpGet("GetTotalCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var result = await _signalRStatisticService.GetTotalCategoryCountAsync();
            return Ok(result);
        }
        
        [HttpGet("GetTotalProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var result = await _signalRStatisticService.GetTotalProductCountAsync();
            return Ok(result);
        }
        
        [HttpGet("GetTotalActiveBookingCount")]
        
        public async Task<IActionResult> GetActiveBookingCount()
        {
            var result = await _signalRStatisticService.GetTotalActiveBookingCountAsync();
            return Ok(result);
        }
        
        [HttpGet("GetTotalPassiveBookingCount")]
        
        public async Task<IActionResult> GetPassiveBookingCount()
        {
            var result = await _signalRStatisticService.GetTotalPassiveBookingCountAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetAveragePrice")]
        
        public async Task<IActionResult> GetAveragePrice()
        {
            var result = await _signalRStatisticService.GetAveragePriceAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetCheapestProduct")]
        
        public async Task<IActionResult> GetCheapestProduct()
        {
            var result = await _signalRStatisticService.GetCheapestProductAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetExpensiveProduct")]
        
        public async Task<IActionResult> GetExpensiveProduct()
        {
            var result = await _signalRStatisticService.GetExpensiveProductAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetTotalProductCountByCategory/{categoryId}")]
        
        public async Task<IActionResult> GetTotalProductCountByCategory(int categoryId)
        {
            var result = await _signalRStatisticService.GetTotalProductCountByCategoryAsync(categoryId);
            return Ok(result);
        }
        
        
        [HttpGet("GetTotalProductCountByCategoryName/{categoryName}")]
        
        public async Task<IActionResult> GetTotalProductCountByCategoryName(string categoryName)
        {
            var result = await _signalRStatisticService.GetTotalProductCountByCategoryNameAsync(categoryName);
            return Ok(result);
        }
        
        
        
        [HttpGet("GetTotalOrderCount")]
        
        public async Task<IActionResult> GetTotalOrderCount()
        {
            var result = await _signalRStatisticService.GetTotalOrderCountAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetTodayTotalCompletedOrderCount")]
        
        public async Task<IActionResult> GetTodayTotalCompletedOrderCount()
        {
            var result = await _signalRStatisticService.GetTodayTotalCompletedOrderCountAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetTotalCashRevenue")]
        
        public async Task<IActionResult> GetTotalCashRevenue()
        {
            var result = await _signalRStatisticService.GetTotalCashRevenueAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetTotalActiveTableCount")]
        
        
        public async Task<IActionResult> GetTotalActiveTableCount()
        {
            var result = await _signalRStatisticService.GetTotalActiveTableCountAsync();
            return Ok(result);
        }
        
        
        [HttpGet("GetTotalPassiveTableCount")]
        
        public async Task<IActionResult> GetTotalPassiveTableCount()
        {
            var result = await _signalRStatisticService.GetTotalPassiveTableCountAsync();
            return Ok(result);
        }
        
        
        
        
        
    }
}
