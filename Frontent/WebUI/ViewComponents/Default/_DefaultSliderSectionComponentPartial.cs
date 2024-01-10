using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultSliderSectionComponentPartial")]
public class DefaultSliderSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IFeatureService _featureService;
    
    public DefaultSliderSectionComponentPartial(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _featureService.GetAllAsync();
        return View(result);
    }
    
}