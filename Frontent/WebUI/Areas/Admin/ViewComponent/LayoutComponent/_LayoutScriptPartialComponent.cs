using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponent.LayoutComponent;

[ViewComponent(Name = "_LayoutScriptPartialComponent")]
public class LayoutScriptPartialComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Logikk for visningskomponenten
        return View();
    }
    
}