using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using DtoLayer.CustomResponseDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : CustomBaseController
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        
        
        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        
       
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _aboutService.GetAllAsync();
            var abouts = _mapper.Map<List<ResultAboutDto>>(result);

            return CreateActionResultInstance(CustomResponseDto<List<ResultAboutDto>>.Success(abouts, 200));
        }

        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(CreateAboutDto about)
        {
            var result = _mapper.Map<About>(about);
            await _aboutService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto about)
        {
            var result = _mapper.Map<About>(about);
            await _aboutService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            await _aboutService.DeleteAsync(result);
            return Ok("Deleted Successfully");
        }
        
        
        
        
    }
}
