using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.OrderDtos;
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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        
        
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        
         
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _orderService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderDto Order)
        {
            var result = _mapper.Map<Order>(Order);
            await _orderService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDto Order)
        {
            var result = _mapper.Map<Order>(Order);
            await _orderService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Order = await _orderService.GetByIdAsync(id);
            await _orderService.DeleteAsync(Order);
            return Ok("Deleted Successfully");
        }
        
        
        
        
    }
}
