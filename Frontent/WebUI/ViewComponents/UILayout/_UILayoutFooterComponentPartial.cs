using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout;
[ViewComponent(Name = "_UILayoutFooterComponentPartial")]
public class UiLayoutFooterComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly IContactService _contactService;
    
    public UiLayoutFooterComponentPartial(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _contactService.GetAllAsync();
        return View(result);
    }
    
}