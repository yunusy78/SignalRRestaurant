using BusinessLayer.Abstract;
using DtoLayer.ShoppingCartDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IDiningTableService _diningTableService;
    private readonly IProductService _productService;
    
    public ShoppingCartController(IShoppingCartService shoppingCartService, IDiningTableService diningTableService, IProductService productService)
    {
        _shoppingCartService = shoppingCartService;
        _diningTableService = diningTableService;
        _productService = productService;
    }
    
    
    public async  Task<IActionResult> Index2()
    {
        var list = new List<SelectListItem>();
        var response = await _diningTableService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                list.Add(new SelectListItem(value.TableName, value.DiningTableId.ToString()));
            }
        }
        
        ViewBag.List = list;
        
        return View();
    }
    // GET
    public async Task<IActionResult> Index(int id)
    {
        var result = await _shoppingCartService.GetAllListByDiningTableAsync(id);
        ViewData["DiningTableName"] = result.FirstOrDefault()?.DiningTableName;
        return View(result);
    }
    
    
    public IActionResult RemoveFromCart(int cartId, int productId, int tableId)
    {
        var result = _shoppingCartService.RemoveRange(cartId,productId);
        return Redirect($"/ShoppingCart/Index/{tableId}");
    }
    public IActionResult IncrementCount(int cartId, int productId, int tableId)
    {
        var result =  _shoppingCartService.IncrementCount(cartId,productId);
        return Redirect($"/ShoppingCart/Index/{tableId}");

    }
    
    public IActionResult DecrementCount(int cartId, int productId, int tableId)
    {
        var result =  _shoppingCartService.DecrementCount(cartId,productId);
        return Redirect($"/ShoppingCart/Index/{tableId}");
        
    }
    

    public async Task<IActionResult> Create(int id)
    {
        var list = new List<SelectListItem>();
        var response = await _diningTableService.GetAllAsync();
        if (response != null)
        {
            foreach (var value in response)
            {
                list.Add(new SelectListItem(value.TableName, value.DiningTableId.ToString()));
            }
        }
        var product=await _productService.GetByIdAsync(id);
        ViewBag.List = list;
        ViewBag.Product = product;
        
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(CreateShoppingCartDto dto)
    {
        dto.CreatedDate=DateTime.Now;
        var response = await _shoppingCartService.CreateBasketAsync(dto);
        if (response)
        {
            
            return Redirect($"/ShoppingCart/Index/{dto.DiningTableId}");

        }

        return RedirectToAction("Index", "Default");


    }
    
   
    
    
    
    
}