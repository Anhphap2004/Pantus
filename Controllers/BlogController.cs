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
            ViewBag.BlogId = id;
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            ViewBag.blogs = _context.TbBlogs.Where(i => i.IsActive).ToList();
            return View(blog);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int blogId, string name, string phone, string email, string message)
        {
            try
            {
                // Kiểm tra xem blogId có hợp lệ không
                var blog = await _context.TbBlogs.FirstOrDefaultAsync(b => b.BlogId == blogId);
                if (blog == null)
                {
                    return Json(new { status = false, message = "Blog không tồn tại." });
                }

                // Tạo đối tượng bình luận mới
                TbBlogComment contact = new TbBlogComment
                {
                    BlogId = blogId,  // Gán BlogId
                    Name = name,
                    Phone = phone,
                    Email = email,
                    Detail = message,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    Image = "havi.jpg",
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
