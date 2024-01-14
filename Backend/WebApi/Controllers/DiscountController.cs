using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiscountDtos;
using DtoLayer.FeatureDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        
        
        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _discountService.GetAllAsync();
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _discountService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateDiscountDto Discount)
        {
            var result = _mapper.Map<Discount>(Discount);
            await _discountService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateDiscountDto Discount)
        {
            var result = _mapper.Map<Discount>(Discount);
            await _discountService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _discountService.GetByIdAsync(id);
            await _discountService.DeleteAsync(discount);
            return Ok("Deleted Successfully");
        }
        
        [HttpGet("CheckDiscountCode")]
        
        public async Task<IActionResult> CheckDiscountCode(string code)
        {
            var result = await _discountService.CheckDiscountCodeAsync(code);
            return Ok(result);
        }
        
        
        
        
    }
}
