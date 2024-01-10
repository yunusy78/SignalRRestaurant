using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout;
[ViewComponent(Name = "_UILayoutHeadComponentPartial")]
public class UiLayoutHeadComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}