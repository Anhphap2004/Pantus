using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;
namespace Pantus.Controllers
{
    public class MenuController : Controller
    {
        private readonly PantusContext _context;
        public MenuController(PantusContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("/menu/{alias}-{id}.html")]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.TbMenuItems == null)
            {
                return NotFound();
            }
            var menuItem = await _context.TbMenuItems.Include(i => i.Category).FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (menuItem == null)
            {
                return NotFound();
            }
            ViewBag.MenuReview = _context.TbMenuReviews.Where(i => i.MenuItemId == id && i.IsActive).ToList();
            ViewBag.MenuRelated = _context.TbMenuItems.Where(i => i.MenuItemId != id && i.CategoryId == menuItem.CategoryId).Take(5).OrderByDescending(i => i.MenuItemId).ToList();
            ViewBag.MenuCategories = _context.TbMenuCategories.Where(i => i.CategoryId == menuItem.CategoryId && i.IsActive).ToList();

            return View(menuItem);
        }
    }
}
