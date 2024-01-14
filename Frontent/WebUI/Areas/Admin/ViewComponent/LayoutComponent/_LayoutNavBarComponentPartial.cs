using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponent.LayoutComponent;


    [ViewComponent(Name = "_LayoutNavbarComponentPartial")]
    public class LayoutNavbarComponentPartialViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IConfiguration _configuration;
        
        public LayoutNavbarComponentPartialViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IViewComponentResult Invoke()
        {
            var hubUrl = _configuration.GetSection("SignalRHubSettings:HubNotificationUrl").Value;
            ViewBag.HubUrl = hubUrl;
            return View();
        }
    
    }