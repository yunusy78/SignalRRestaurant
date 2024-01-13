using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class BookingTableController : Controller
{
    private readonly IReservationService _reservationService;
    
    public BookingTableController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateReservationDto createBookingDto)
    {
            var result = await _reservationService.CreateReservationAsync(createBookingDto);
            if (result)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
    }
    
}