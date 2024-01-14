
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.TestimonialDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        
        
        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _testimonialService.GetAllAsync();
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _testimonialService.GetByIdAsync(id);
            return Ok(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateTestimonialDto Testimonial)
        {
            var result = _mapper.Map<Testimonial>(Testimonial);
            await _testimonialService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateTestimonialDto Testimonial)
        {
            var result = _mapper.Map<Testimonial>(Testimonial);
            await _testimonialService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _testimonialService.GetByIdAsync(id);
            await _testimonialService.DeleteAsync(result);
            return Ok("Deleted Successfully");
        }
        
        
        
        
    }
}
