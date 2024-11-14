using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;

namespace Pantus.Controllers
{
    public class BlogController : Controller
    {
        private readonly PantusContext _context;
        public BlogController(PantusContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [Route("/blog/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbBlogs == null)
            {
                return NotFound();
            }
            var blog = await _context.TbBlogs.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            ViewBag.blogs = _context.TbBlogs.Where(i => i.IsActive).ToList();
            return View(blog);
        }

    }
}
