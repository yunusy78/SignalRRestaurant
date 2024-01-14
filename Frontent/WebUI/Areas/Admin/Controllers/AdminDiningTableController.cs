using BusinessLayer.Abstract;
using DtoLayer.AboutDtos;
using DtoLayer.DiningTableDtos;
using Microsoft.AspNetCore.Mvc;
namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminDiningTableController : Controller
    {
        private readonly IDiningTableService _diningTableService;
        private readonly IConfiguration _configuration;
    
        public AdminDiningTableController(IDiningTableService diningTableService, IConfiguration configuration)
        {
            _diningTableService = diningTableService;
            _configuration = configuration;
        }
    
        // GET
        public async Task<IActionResult> Index()
        {
            var result = await _diningTableService.GetAllAsync();
            return View(result);
        
        }
    
        public IActionResult Create()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> Create(CreateDiningTableDto dto)
        {
            var result = await _diningTableService.AddAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminDiningTable/Index");
            }
            return View(dto);
        }
    
        public async Task<IActionResult> Update(int id)
        {
            var result = await _diningTableService.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
    
    
        [HttpPost]
        public async Task<IActionResult> Update(UpdateDiningTableDto dto)
        {
            var result = await _diningTableService.UpdateAsync(dto);
            if (result)
            {
                return Redirect("/Admin/AdminDiningTable/Index");
            }
            return View();
        }
    
        public async Task<IActionResult> Delete(int id)
        {
        
            var result = await _diningTableService.DeleteAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("/Admin/AdminDiningTable/Index");
        }
        
        public async Task<IActionResult> TableListByStatus()
        {
            var hubUrl = _configuration.GetSection("SignalRHubSettings:HubBookingUrl").Value;
            ViewBag.HubUrl = hubUrl!;
            var result = await _diningTableService.GetAllAsync();
            return View(result);
        }
    
    }
}