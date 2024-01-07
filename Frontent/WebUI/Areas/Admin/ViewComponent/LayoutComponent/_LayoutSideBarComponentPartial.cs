using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponent.LayoutComponent;

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
