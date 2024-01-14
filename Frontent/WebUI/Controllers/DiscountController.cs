using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers;

public class DiscountController : Controller
{
    private readonly IDiscountService _discountService;
    
    public DiscountController(IDiscountService discountService)
    {
        _discountService = discountService;
    }
    // GET
    [HttpPost]
    public async Task<IActionResult> ApplyDiscount([FromBody] DiscountRequestModel model)
    {
        if (model == null || string.IsNullOrWhiteSpace(model.Code))
        {
            return BadRequest(new { success = false, error = "Invalid request data" });
        }

        var result = await _discountService.CheckDiscountCodeAsync(model.Code);
        if (result == 0)
        {
            return BadRequest(new { success = false, error = "Invalid Discount Code" });
        }

        return Ok(new { success = true, amount = result });
    }

    
}