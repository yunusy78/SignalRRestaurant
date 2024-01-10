using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout;
[ViewComponent(Name = "_UILayoutNavBarComponentPartial")]
public class UiLayoutNavBarComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}