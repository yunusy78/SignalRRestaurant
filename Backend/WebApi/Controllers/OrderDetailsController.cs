using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OrderDetailsDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly IMapper _mapper;
        
        
        public OrderDetailsController(IOrderDetailsService orderDetailsService, IMapper mapper)
        {
            _orderDetailsService = orderDetailsService;
            _mapper = mapper;
        }
        
         
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _orderDetailsService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderDetailsService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderDetailsDto orderDetails)
        {
            var result = _mapper.Map<OrderDetails>(orderDetails);
            await _orderDetailsService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailsDto orderDetails)
        {
            var result = _mapper.Map<OrderDetails>(orderDetails);
            await _orderDetailsService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var orderDetails = await _orderDetailsService.GetByIdAsync(id);
            await _orderDetailsService.DeleteAsync(orderDetails);
            return Ok("Deleted Successfully");
        }
        
        [AllowAnonymous]
        [HttpGet("GetOrderDetailsByOrderWithProductName")]
        
        public async Task<IActionResult> GetOrderDetailsByOrderWithProductName()
        {
            var result = await _orderDetailsService.GetOrderDetailsByOrderWithProductName();
            return Ok(result);
        }
        
        
        
        
    }
}
