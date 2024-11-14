using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;

namespace Pantus.ViewComponents
{
    public class EventViewComponent : ViewComponent
    {
        private readonly PantusContext _context;

        public EventViewComponent(PantusContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var events = await _context.TbEvents
                .Where(e => e.IsActive)
                .OrderByDescending(e => e.CreatedDate) 
                .ToListAsync();

            return View(events); 
        }
    }
}
