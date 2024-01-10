using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultCategorySectionComponentPartial")]
public class DefaultCategorySectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly ICategoryService _categoryService;
    
    public DefaultCategorySectionComponentPartial(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _categoryService.GetAllAsync();
        return View(result);
    }
    
}