using BusinessLayer.Abstract;
using DtoLayer.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminFeatureController : Controller
{
    private readonly IFeatureService _featureService;
    
    public AdminFeatureController(IFeatureService featureService)
    {
        _featureService = featureService;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var features = await _featureService.GetAllAsync();
        return View(features);
        
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateFeatureDto featureDto)
    {
        if (!ModelState.IsValid)
        {
            return View(featureDto);
        }
        var result = await _featureService.AddAsync(featureDto);
        if (result)
        {
            return Redirect("/Admin/AdminFeature/Index");
        }
        return View(featureDto);
    }
    
    public async Task<IActionResult> Update(int id)
    {
        var feature = await _featureService.GetByIdAsync(id);
        if (feature == null)
        {
            return NotFound();
        }
        return View(feature);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Update(UpdateFeatureDto featureDto)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var result = await _featureService.UpdateAsync(featureDto);
        if (result)
        {
            return Redirect("/Admin/AdminFeature/Index");
        }
        return View();
    }
    
    public async Task<IActionResult> Delete(int id)
    {
        var feature = await _featureService.DeleteAsync(id);
        if (feature == null)
        {
            return NotFound();
        }
        return Redirect("/Admin/AdminFeature/Index");
    }
    
}