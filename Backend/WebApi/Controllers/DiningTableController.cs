using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.DiningTableDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
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
        
       
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _diningTableService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _diningTableService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(DiningTable dto)
        {
            await _diningTableService.AddAsync(dto);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(DiningTable dto)
        {
            
            await _diningTableService.UpdateAsync(dto);
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
