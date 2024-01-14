using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default;
[ViewComponent(Name = "_DefaultMessageSectionComponentPartial")]
public class DefaultMessageSectionComponentPartial : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}