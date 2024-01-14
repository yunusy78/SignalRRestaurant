using BusinessLayer.Abstract;
using DtoLayer.BookingDtos;
using Microsoft.AspNetCore.Mvc;


namespace WebUI.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminReservationController : Controller
{
   private readonly IReservationService _reservationService;
   private readonly IConfiguration _configuration;

    public AdminReservationController(IReservationService reservationService, IConfiguration configuration)
    {
         _reservationService = reservationService;
         _configuration = configuration;
    }


   // GET
    public async Task<IActionResult> Index()
    {
        var hubUrl = _configuration.GetSection("SignalRHubSettings:HubBookingUrl").Value;
        ViewBag.HubUrl = hubUrl;
        var response = await _reservationService.GetAllAsync();
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpGet]
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Create(CreateReservationDto dto)
    {
        
            var response = await _reservationService.CreateReservationAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminReservation/Index");
            }
        return View(dto);
    }
    
    
    [HttpGet]
    
    public async Task<IActionResult> Update(int id)
    {
        var response = await _reservationService.GetByIdAsync(id);
        if (response != null)
        {
            return View(response);
        }
        return View();
    }
    
    [HttpPost]
    
    public async Task<IActionResult> Update(UpdateReservationDto dto)
    {
        
        
            var response = await _reservationService.UpdateReservationAsync(dto);
            if (response)
            {
                return Redirect("/Admin/AdminReservation/Index");
            }
        return View();
    }
    
    
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _reservationService.DeleteAsync(id);
        if (response)
        {
            return Redirect("/Admin/AdminReservation/Index");
        }
        return Redirect("/Admin/AdminReservation/Index");
    }
    
    
    

   
}