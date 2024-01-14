using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DiningTableController : ControllerBase
    {
        private readonly IDiningTableService _diningTableService;
        private readonly IMapper _mapper;
        
        
        public DiningTableController(IDiningTableService diningTableService, IMapper mapper)
        {
            _diningTableService = diningTableService;
            _mapper = mapper;
        }
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            
            var result = await _diningTableService.GetAllAsync();
            var resultDto = _mapper.Map<List<ResultDiningTableDto>>(result);
            return Ok(resultDto);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _diningTableService.GetByIdAsync(id);
            var resultDto = _mapper.Map<ResultDiningTableDto>(result);
            return Ok(resultDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateDiningTableDto dto)
        {
            var result = _mapper.Map<DiningTable>(dto);
            await _diningTableService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateDiningTableDto dto)
        {
            var result = _mapper.Map<DiningTable>(dto);
            await _diningTableService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _diningTableService.GetByIdAsync(id);
            await _diningTableService.DeleteAsync(result);
            return Ok("Deleted Successfully");
        }
        
        
        
        
        
    }
}
