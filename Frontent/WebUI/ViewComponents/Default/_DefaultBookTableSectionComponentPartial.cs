using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;
[ViewComponent(Name = "_DefaultBookTableSectionComponentPartial")]
public class DefaultBookTableSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}