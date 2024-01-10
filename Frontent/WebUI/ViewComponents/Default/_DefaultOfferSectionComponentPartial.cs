using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultOfferSectionComponentPartial")]
public class DefaultOfferSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IDiscountService _discountService;
    
    public DefaultOfferSectionComponentPartial(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _discountService.GetAllAsync();
        return View(result);
    }
    
}