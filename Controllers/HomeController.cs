using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pantus.Models;
using Pantus.Utilities;
namespace Pantus.Controllers
{
    public class HomeController : Controller
    {
        private readonly PantusContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(PantusContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            ViewBag.MenuCategories = _context.TbMenuCategories.ToList();
           return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Menu()
        {
            ViewBag.MenuCategories = _context.TbMenuCategories.ToList();
            
            return View();
        }
        public IActionResult Booking()
        {
            return View();
        }
       
        public IActionResult Services()
        {
            ViewBag.Services = _context.TbServices.ToList();
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public Task<IActionResult> Logout()
        {
            // Logic xử lý logout
            Function._AccountId = 0;
            Function._Message = string.Empty;
            Function._MessageEmail = string.Empty;
            Function._Email = string.Empty;
            Function._Username = string.Empty;
            return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
        }
    }
}
