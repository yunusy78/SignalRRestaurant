using BusinessLayer.Abstract;
using DtoLayer.OrderDtos;
using DtoLayer.ShoppingCartDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;
    
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    [HttpPost]
    public IActionResult Add(string totalAmount)
    {
        CreateOrderDto createOrderDto = new CreateOrderDto();
        
        
        createOrderDto.TableNumber = ViewData["DiningTableName"]!.ToString();
        createOrderDto.Description = "Merhaba";
        createOrderDto.TotalPrice = Convert.ToDecimal(totalAmount);
        createOrderDto.Status = true;
        createOrderDto.OrderDate = DateTime.Now;
        _orderService.CreateAsync(createOrderDto);
        return RedirectToAction("Index", "Default");
    }
    
   
    
    
    
}