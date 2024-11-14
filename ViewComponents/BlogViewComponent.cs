using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models; 

namespace Pantus.ViewComponents
{
    public class BlogViewComponent : ViewComponent
    {
        private readonly PantusContext _context;

        public BlogViewComponent(PantusContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _context.TbBlogs 
                .Where(b => b.IsActive)  
                .OrderByDescending(b => b.CreatedDate) 
                .ToListAsync();

            return View(blogs); 
        }
    }
}
