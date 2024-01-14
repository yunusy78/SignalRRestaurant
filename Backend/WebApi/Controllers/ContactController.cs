using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.ContactDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        
        
        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        
       
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _contactService.GetAllAsync();
            return Ok(result);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(CreateContactDto Contact)
        {
            var result = _mapper.Map<Contact>(Contact);
            await _contactService.AddAsync(result);
            return Ok("Added Successfully");
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto Contact)
        {
            var result = _mapper.Map<Contact>(Contact);
            await _contactService.UpdateAsync(result);
            return Ok("Updated Successfully");
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contact = await _contactService.GetByIdAsync(id);
            await _contactService.DeleteAsync(contact);
            return Ok("Deleted Successfully");
        }
        
        
        
        
    }
}
