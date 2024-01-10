using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;

[ViewComponent(Name = "_DefaultTestimonialSectionComponentPartial")]
public class DefaultTestimonialSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly ITestimonialService _service  ;
    
    public DefaultTestimonialSectionComponentPartial(ITestimonialService service)
    {
        _service = service;
    }
    
    
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _service.GetAllAsync();
        return View(result);
    }
    
}