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
            ViewBag.menuid = id;
            ViewBag.MenuReview = _context.TbMenuReviews.Where(i => i.MenuItemId == id && i.IsActive).ToList();
            ViewBag.MenuRelated = _context.TbMenuItems.Where(i => i.MenuItemId != id && i.CategoryId == menuItem.CategoryId).Take(5).OrderByDescending(i => i.MenuItemId).ToList();
            ViewBag.MenuCategories = _context.TbMenuCategories.Where(i => i.CategoryId == menuItem.CategoryId && i.IsActive).ToList();

            return View(menuItem);
        }
         [HttpPost]
        public async Task<IActionResult> Create(int menuid, string name, int phone, int rating, string message)
        {
            try
            {
                // Kiểm tra xem blogId có hợp lệ không
                var menu = await _context.TbMenuItems.FirstOrDefaultAsync(b => b.MenuItemId == menuid);
                if (menu == null)
                {
                    return Json(new { status = false, message = "Menu không tồn tại." });
                }

                // Tạo đối tượng bình luận mới
                TbMenuReview contact = new TbMenuReview
                {
                    MenuItemId = menuid, // Gán BlogId
                    Name = name,
                    Phone = phone,
                    Rating = rating,
                    Detail = message,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Image = "/assets/img/userreview/havi.jpg",
                };

                // Thêm vào cơ sở dữ liệu
                _context.Add(contact);
                await _context.SaveChangesAsync(); // Lưu thay đổi

                return Json(new { status = true });
            }
            catch
            {
                return Json(new { status = false });
            }
        }
    }
}
