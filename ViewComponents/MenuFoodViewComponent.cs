using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;

namespace Pantus.ViewComponents
{
    public class MenuFoodViewComponent : ViewComponent
    {
        private readonly PantusContext _context;

        public MenuFoodViewComponent(PantusContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbMenuItems
                .Where(m => m.IsActive) 
                .ToListAsync();
            return View(items); 
        }
    }
}
