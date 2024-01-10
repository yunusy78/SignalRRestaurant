using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout;

[ViewComponent(Name = "_UILayoutSocialMediaComponentPartial")]
public class UiLayoutSocialMediaComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly ISocialMediaService _socialMediaService;
    
    public UiLayoutSocialMediaComponentPartial(ISocialMediaService socialMediaService)
    {
        _socialMediaService = socialMediaService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _socialMediaService.GetAllAsync();
        return View(result);
    }
    
}