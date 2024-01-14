using System.Globalization;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class ChartController : Controller
{
    private readonly IOrderDetailsService _reservationService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    
    
    public ChartController(IOrderDetailsService reservationService, IOrderService orderService, IProductService productService, ICategoryService categoryService)
    {
        _reservationService = reservationService;
        _orderService = orderService;
        _productService = productService;
        _categoryService = categoryService;
    }
    
   
    
    
    // GET
    public async Task<IActionResult> Index()
    {
        try
        {
            var reservationsWithCar = await _reservationService.GetOrderDetailsByOrderWithProductName();
            
            var carCounts = reservationsWithCar
                .GroupBy(r => r.ProductId)
                .Select(group => new
                {
                    Name = group.First().ProductName,
                    Count = group.Count()
                })
                .ToList();

            return View(carCounts);
        }
        catch (Exception ex)
        {
            // Log the exception or handle it appropriately
            return View(new List<object>()); // or an empty model depending on your View
        }
    }


    public IActionResult Index2()
    {
        return View();
    }
    
    
    public async Task<IActionResult> OrderChart()
    {
        try
        {
            var productList = await _productService.GetAllAsync();

            if (productList == null)
            {
                // productList null ise yapılacak işlemler veya bir hata mesajı
                return BadRequest("Ürün listesi alınamadı.");
            }

            var jsonProductList = new List<object>();

            foreach (var productDto in productList)
            {
                var orders = await _reservationService.GetOrderDetailsByOrderWithProductName();

                if (orders == null)
                {
                    // orders null ise yapılacak işlemler veya bir hata mesajı
                    return BadRequest("Sipariş listesi alınamadı.");
                }

                var orderCount = orders.Count(x => x != null && x.ProductId == productDto.ProductId);

                var jsonOrderCount = new
                {
                    Name = productDto.ProductName,
                    Count = orderCount
                };

                jsonProductList.Add(jsonOrderCount);
            }

            return Json(new { jsonlist = jsonProductList });
        }
        catch (Exception ex)
        {
            // Hata durumunda yapılacak işlemler veya bir hata mesajı
            return StatusCode(500, "Bir hata oluştu. Hata detayı: " + ex.Message);
        }
    }


    
    
    public async Task<IActionResult> RevenueChart()
    {
        try
        {
            var orders = await _orderService.GetAllAsync();

            if (orders == null)
            {
                // orders null ise yapılacak işlemler veya bir hata mesajı
                return BadRequest("Sipariş listesi alınamadı.");
            }

            var revenueByMonth = orders
                .GroupBy(x => x.OrderDate.Month)
                .Select(group => new
                {
                    Month = group.Key.ToString(),
                    Revenue = group.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.Month)
                .ToList();

            var months = revenueByMonth.Select(x => x.Month).ToArray();
            var revenues = revenueByMonth.Select(x => x.Revenue).ToArray();

            return Json(new { Months = months, Revenues = revenues });
        }
        catch (Exception ex)
        {
            // Hata durumunda yapılacak işlemler veya bir hata mesajı
            return StatusCode(500, "Bir hata oluştu. Hata detayı: " + ex.Message);
        }
    }

    
    public async Task<IActionResult> RevenueChartByWeek()
    {
        try
        {
            var orders = await _orderService.GetAllAsync();

            if (orders == null)
            {
                // orders null ise yapılacak işlemler veya bir hata mesajı
                return BadRequest("Sipariş listesi alınamadı.");
            }

            var revenueByWeek = orders
                .GroupBy(x => CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                    new DateTime(x.OrderDate.Year, x.OrderDate.Month, x.OrderDate.Day),
                    CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
                .Select(group => new
                {
                    Week = group.Key.ToString(),
                    Revenue = group.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.Week)
                .ToList();

            var weeks = revenueByWeek.Select(x => x.Week).ToArray();
            var revenues = revenueByWeek.Select(x => x.Revenue).ToArray();

            return Json(new { Weeks = weeks, Revenues = revenues });
        }
        catch (Exception ex)
        {
            // Hata durumunda yapılacak işlemler veya bir hata mesajı
            return StatusCode(500, "Bir hata oluştu. Hata detayı: " + ex.Message);
        }
    }

    
    public async Task<IActionResult> RevenueChartByDayOfWeek()
    {
        try
        {
            var orders = await _orderService.GetAllAsync();

            if (orders == null)
            {
                // orders null ise yapılacak işlemler veya bir hata mesajı
                return BadRequest("Sipariş listesi alınamadı.");
            }

            var revenueByDayOfWeek = orders
                .GroupBy(x => x.OrderDate.DayOfWeek)
                .Select(group => new
                {
                    DayOfWeekNumber = (int)group.Key,
                    Revenue = group.Sum(x => x.TotalPrice)
                })
                .OrderBy(x => x.DayOfWeekNumber)
                .ToList();

            var daysOfWeekNumbers = revenueByDayOfWeek.Select(x => x.DayOfWeekNumber).ToArray();
            var revenues = revenueByDayOfWeek.Select(x => x.Revenue).ToArray();

            return Json(new { DayOfWeek = daysOfWeekNumbers, Revenues = revenues });
        }
        catch (Exception ex)
        {
            // Hata durumunda yapılacak işlemler veya bir hata mesajı
            return StatusCode(500, "Bir hata oluştu. Hata detayı: " + ex.Message);
        }
    }





}