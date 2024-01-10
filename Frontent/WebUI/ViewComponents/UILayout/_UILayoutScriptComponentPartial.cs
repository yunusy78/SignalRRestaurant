using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.UILayout;
[ViewComponent(Name = "_UILayoutScriptComponentPartial")]
public class UiLayoutScriptComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}