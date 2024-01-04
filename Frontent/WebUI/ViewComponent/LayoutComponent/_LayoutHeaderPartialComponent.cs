﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponent.LayoutComponent;

[ViewComponent(Name = "_LayoutHeaderPartialComponent")]
public class LayoutHeaderPartialComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    public IViewComponentResult Invoke()
    {
        // Logikk for visningskomponenten
        return View();
    }
    
}