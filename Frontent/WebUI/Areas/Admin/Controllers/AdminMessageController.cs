using BusinessLayer.Abstract;
using DtoLayer.ContactDtos;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactService _contactService;
    
        public AdminContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _contactService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            dto.CreatedAt = DateTime.Now;
            var result = await _contactService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminContact/Index");
            }
            return View(dto);
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _contactService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            var result = await _contactService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminContact/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _contactService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminContact/Index");
        }
    
    }
}