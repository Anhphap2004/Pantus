using Pantus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pantus.ViewComponents
{
    public class ServicesViewComponent : ViewComponent
    {
        private readonly PantusContext _context;

        public ServicesViewComponent(PantusContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbServices
                .Where(s => s.IsActive)
                .ToListAsync();
            return View(items);
        }
    }
}
