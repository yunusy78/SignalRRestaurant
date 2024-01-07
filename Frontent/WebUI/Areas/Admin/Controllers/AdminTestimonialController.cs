using BusinessLayer.Abstract;
using DtoLayer.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminTestimonialController : Controller
{
   private readonly ITestimonialService _testimonialService;

   public AdminTestimonialController(ITestimonialService testimonialService)
   {
       _testimonialService = testimonialService;
   }


   // GET
    public async Task<IActionResult> Index()
    {
        var response = await _testimonialService.GetAllAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(CreateTestimonialDto testimonialDto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Testimonial/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            testimonialDto.ImageUrl =@"ImageFile/Testimonial/"+ fileName;
        }
        else
        {
            testimonialDto.ImageUrl = "default.jpg";
        }
        
            var response = await _testimonialService.AddAsync(testimonialDto);
            if (response)
            {
                return Redirect("/Admin/AdminTestimonial/Index");
            }
        return View(testimonialDto);
    }
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _testimonialService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(UpdateTestimonialDto testimonialDto, IFormFile file)
    {
        if (file != null)
        {
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Testimonial/" + fileName);
            var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            testimonialDto.ImageUrl =@"ImageFile/Testimonial/"+ fileName;
        }
        else
        {
            testimonialDto.ImageUrl = testimonialDto.ImageUrl;
        }
        
       
            var response = await _testimonialService.UpdateAsync(testimonialDto);
            if (response)
            {
                return Redirect("/Admin/AdminTestimonial/Index");
            }
        return View();
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _testimonialService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminTestimonial/Index");
        }
        return Redirect("/Admin/AdminTestimonial/Index");
    }
    
    
    

   
}