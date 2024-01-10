using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultFoodSectionComponentPartial")]
public class DefaultFoodSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IProductService _productService;
    
    public DefaultFoodSectionComponentPartial(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _productService.GetListWithCategoryAsync();
        return View(result);
    }
    
}