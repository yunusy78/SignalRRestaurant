using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
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
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        
        
        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _featureService.GetAllAsync();
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _featureService.GetByIdAsync(id);
            return Ok(result);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateFeatureDto Feature)
        {
            var result = _mapper.Map<Feature>(Feature);
            await _featureService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateFeatureDto Feature)
        {
            var result = _mapper.Map<Feature>(Feature);
            await _featureService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var feature = await _featureService.GetByIdAsync(id);
            await _featureService.DeleteAsync(feature);
            return Ok("Deleted Successfully");
        }
        
        
        
        
    }
}
