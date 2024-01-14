using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.MessageDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        
        
        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        
       
        
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            
            var result = await _messageService.GetAllAsync();
            var resultDto = _mapper.Map<List<ResultMessageDto>>(result);
            return Ok(resultDto);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _messageService.GetByIdAsync(id);
            var resultDto = _mapper.Map<ResultMessageDto>(result);
            return Ok(resultDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateMessageDto dto)
        {
            var result = _mapper.Map<Message>(dto);
            await _messageService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        
        public async Task<IActionResult> Update(UpdateMessageDto dto)
        {
            var result = _mapper.Map<Message>(dto);
            await _messageService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _messageService.GetByIdAsync(id);
            await _messageService.DeleteAsync(result);
            return Ok("Deleted Successfully");
        }
        
        
        
        
        
    }
}
