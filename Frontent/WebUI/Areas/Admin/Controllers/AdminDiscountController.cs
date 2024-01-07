using BusinessLayer.Abstract;
using DtoLayer.DiscountDtos;
using DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDiscountController : Controller
    {
        private readonly IDiscountService _discountService;
    
        public AdminDiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _discountService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiscountDto dto, IFormFile file)
        {
            dto.CreatedAt = DateTime.Now;
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Discount/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                dto.ImageUrl =@"ImageFile/Discount/"+ fileName;
            }
            else
            {
                dto.ImageUrl = "default.jpg";
            }
            
            var result = await _discountService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminDiscount/Index");
            }
            return View(dto);
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _discountService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiscountDto dto, IFormFile file)
        {
            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Discount/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file.CopyToAsync(stream);
                dto.ImageUrl =@"ImageFile/Discount/"+ fileName;
            }
            else
            {
                dto.ImageUrl = dto.ImageUrl;
            }
            
            var result = await _discountService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminDiscount/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _discountService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminDiscount/Index");
        }
    
    }
}