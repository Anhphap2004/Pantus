using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;

namespace Pantus.Controllers
{
    public class EventController : Controller
    {
        private readonly PantusContext _context;
        public EventController(PantusContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Route("/event/{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbEvents == null)
            {
                return NotFound();
            }
            var events = await _context.TbEvents.FirstOrDefaultAsync(m => m.EventId == id);
            if (events == null)
            {
                return NotFound();
            }
            ViewBag.differrentEvent = _context.TbEvents.Where(m => m.EventId != id).ToList() ?? new List<TbEvent>();

            return View(events);
        }
    }
}