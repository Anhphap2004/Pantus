using Microsoft.AspNetCore.Mvc;
using Pantus.Models;

namespace Pantus.Controllers
{
    public class BookingController : Controller
    {
        private readonly PantusContext _context;
        private readonly ILogger<BookingController> _logger;

        public BookingController(PantusContext context, ILogger<BookingController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Booking")]
        public async Task<IActionResult> SubmitBooking(TbTable mn)
        {
            if (mn.FullName == null || mn.Phone == null || mn.People == 0)
            {
                ViewBag.Message = "Quý khách vui lòng nhập đầy đủ thông tin";
                return View("Booking", mn);
            }

            mn.IsActive = true;
            mn.TableNumber = "Bàn 1";
            _context.TbTables.Add(mn);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Đặt bàn thành công!";
            return RedirectToAction("Booking");
        }
    }
}
