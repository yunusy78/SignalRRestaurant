using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponent.LayoutComponent;

using Microsoft.AspNetCore.Mvc;

[ViewComponent(Name = "_LayoutSidebarComponentPartial")]
public class LayoutSidebarComponentPartialViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Logikk for visningskomponenten
        return View();
    }
}
