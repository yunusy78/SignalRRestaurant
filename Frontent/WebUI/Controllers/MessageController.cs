using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class MessageController : Controller
{
    private readonly IMessageService _service;
    
    public MessageController(IMessageService service)
    {
        _service = service;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateMessageDto dto)
    {
        dto.CreatedAt = DateTime.Now;
            var result = await _service.AddAsync(dto);
            if (result)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
    }
    
}