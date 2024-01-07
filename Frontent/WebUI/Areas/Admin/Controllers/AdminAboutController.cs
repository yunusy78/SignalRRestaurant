using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;
    
        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _aboutService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto dto, IFormFile file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/About/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                dto.ImageUrl =@"ImageFile/About/"+ fileName;
            }
            else
            {
                dto.ImageUrl = "default.jpg";
            }
        
       
            var result = await _aboutService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminAbout/Index");
            }
            return View(dto);
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _aboutService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateAboutDto dto, IFormFile file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/About/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                dto.ImageUrl =@"ImageFile/About/"+ fileName;
            }
            else
            {
                dto.ImageUrl = dto.ImageUrl;
            }
        
            var result = await _aboutService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminAbout/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _aboutService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminAbout/Index");
        }
    
    }
}