using Pantus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pantus.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent //Lớp MenuTopViewComponent kế thừa từ ViewComponent.
    {
        private readonly PantusContext _context;

        public MenuTopViewComponent(PantusContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _context.TbMenus
                .Where(m => m.IsActive) 
                .OrderBy(m => m.Position)
                .ToListAsync(); 

            return View(items);  
        }
    }
}
