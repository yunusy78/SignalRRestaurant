using BusinessLayer.Abstract;
using DtoLayer.MessageDtos;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _messageService;
    
        public AdminMessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _messageService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDto dto)
        {
            dto.CreatedAt = DateTime.Now;
            var result = await _messageService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminMessage/Index");
            }
            return View(dto);
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _messageService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMessageDto dto)
        {
            var result = await _messageService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminMessage/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _messageService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminMessage/Index");
        }
    
    }
}