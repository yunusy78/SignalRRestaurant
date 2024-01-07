
using BusinessLayer.Abstract;
using DtoLayer.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public AdminProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var blogs = await _productService.GetAllAsync();
        if (blogs != null)
        {
            return View(blogs);
        }

        return View();
    }

    public async Task<IActionResult> Create()
    {
        var categoryList = new List<SelectListItem>();
        var response = await _categoryService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                categoryList.Add(new SelectListItem(value.CategoryName, value.CategoryId.ToString()));
            }
        }
        
        ViewBag.BlogCategoryList = categoryList;
        
        return View();
    }

    [HttpPost]

    public async Task<IActionResult> Create(CreateProductDto blogDto, IFormFile file1)
    {
       
            if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Product/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file1.CopyToAsync(stream);
                blogDto.ImageUrl =@"ImageFile/Product/"+ fileName;
            }
            else
            {
                blogDto.ImageUrl = "default.jpg";
            }
            
            
            var result = await _productService.AddAsync(blogDto);
            
            if (result)
            {
                return Redirect("/Admin/AdminProduct/Index");
            }

        return View(blogDto);
    }


    public async Task<IActionResult> Update(int id)
    {
        var categoryList = new List<SelectListItem>();
        var response = await _categoryService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                categoryList.Add(new SelectListItem(value.CategoryName, value.CategoryId.ToString()));
            }
        }
        
        ViewBag.BlogCategoryList = categoryList;
        
        var productDto = await _productService.GetByIdAsync(id);
        if (productDto != null)
        {
            return View(productDto);
        }

        return View();
    }


    [HttpPost]

    public async Task<IActionResult> Update(UpdateProductDto dto, IFormFile file1)
    {
        if (ModelState.IsValid)
        {
            if (file1 != null)
            {
                var fileName = Path.GetFileName(file1.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/ImageFile/Product/" + fileName);
                var stream = new FileStream(filePath, FileMode.Create);
                await file1.CopyToAsync(stream);
                dto.ImageUrl =@"ImageFile/Product/"+ fileName;
            }
            else
            {
                dto.ImageUrl = dto.ImageUrl;
            }
            
            var result = await _productService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminProduct/Index");
            }
        }

        return View();
    }


    public async Task<IActionResult> Delete(int id)
    {
        var result = await _productService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminProduct/Index");
        }

        return Redirect("/Admin/AdminProduct/Index");
    }

}