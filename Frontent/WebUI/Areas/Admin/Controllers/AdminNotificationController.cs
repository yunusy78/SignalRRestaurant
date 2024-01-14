using BusinessLayer.Abstract;
using DtoLayer.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminNotificationController : Controller
    {
        private readonly INotificationService _notificationService;
    
        public AdminNotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _notificationService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            var viewModel = new NotificationAdminTypeModel();
            return View(viewModel);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateNotificationDto dto)
        {
            dto.CreatedAt = DateTime.Now;
            dto.IsRead = false;
            var result = await _notificationService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminNotification/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _notificationService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateNotificationDto dto)
        {
            var result = await _notificationService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminNotification/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _notificationService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminNotification/Index");
        }
    
    }
}