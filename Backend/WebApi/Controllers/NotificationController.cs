using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.NotificationDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        
        
        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        
       
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            
            var result = await _notificationService.GetAllAsync();
            var resultDto = _mapper.Map<List<ResultNotificationDto>>(result);
            return Ok(resultDto);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _notificationService.GetByIdAsync(id);
            var resultDto = _mapper.Map<ResultNotificationDto>(result);
            return Ok(resultDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateNotificationDto dto)
        {
            var result = _mapper.Map<Notification>(dto);
            await _notificationService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateNotificationDto dto)
        {
            var result = _mapper.Map<Notification>(dto);
            await _notificationService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _notificationService.GetByIdAsync(id);
            await _notificationService.DeleteAsync(result);
            return Ok("Deleted Successfully");
        }
        
        [HttpGet("GetNotificationCountByStatus")]
        
        public async Task<IActionResult> GetNotificationCountByStatus()
        {
            var result =  await _notificationService.GetNotificationCountByStatus();
            return Ok(result);
        }
        
        [HttpGet("GetNotificationListByStatus")]
        
        public async Task< IActionResult> GetNotificationListByStatus()
        {
            var result = await _notificationService.GetNotificationListByStatus();
            return Ok(result);
        }
        
        
        
        
        
    }
}
