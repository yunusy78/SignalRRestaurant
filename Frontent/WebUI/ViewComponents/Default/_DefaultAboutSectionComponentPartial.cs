using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultAboutSectionComponentPartial")]
public class DefaultAboutSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IAboutService _aboutService;
    
    public DefaultAboutSectionComponentPartial(IAboutService aboutService)
    {
        _aboutService = aboutService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _aboutService.GetAllAsync();
        return View(result);
    }
    
}