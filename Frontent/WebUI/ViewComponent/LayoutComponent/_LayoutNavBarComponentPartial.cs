using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponent.LayoutComponent;


    [ViewComponent(Name = "_LayoutNavbarComponentPartial")]
    public class LayoutNavbarComponentPartialViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Logikk for visningskomponenten
            return View();
        }
    
    }