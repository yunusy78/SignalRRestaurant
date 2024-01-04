﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponent.LayoutComponent;

[ViewComponent(Name = "_LayoutFooterPartialComponent")]
public class LayoutFooterPartialComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Logikk for visningskomponenten
        return View();
    }
    
}