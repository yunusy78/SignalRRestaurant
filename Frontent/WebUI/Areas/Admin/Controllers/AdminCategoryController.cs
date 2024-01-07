
using BusinessLayer.Abstract;
using DtoLayer.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminCategoryController : Controller
{
    private readonly ICategoryService _categoryService;
    
    public AdminCategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var blogCategories = await _categoryService.GetAllAsync();
        if (blogCategories != null)
        {
            return View(blogCategories);
        }
        return View();
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(CreateCategoryDto blogCategoryDto)
    {
        
            var result = await _categoryService.AddAsync(blogCategoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminCategory/Index");
            }
            
        return View(blogCategoryDto);
    }
    
    
    public async Task<IActionResult> Update(int id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category != null)
        {
            return View(category);
        }
        return View();
    }
    
    
    [HttpPost]
    
    public async Task<IActionResult> Update(UpdateCategoryDto categoryDto)
    {
        
            var result = await _categoryService.UpdateAsync(categoryDto);
            if (result)
            {
                return Redirect("/Admin/AdminCategory/Index");
            }
        
        return View();
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _categoryService.DeleteAsync(id);
        if (result)
        {
            return Redirect("/Admin/AdminCategory/Index");
        }
        return Redirect("/Admin/AdminCategory/Index");
    }
    
}