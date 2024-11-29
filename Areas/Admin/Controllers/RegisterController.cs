using Microsoft.AspNetCore.Mvc;
using Pantus.Models;
using Pantus.Utilities;
using Pantus.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
namespace Pantus.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly PantusContext _context;
        public RegisterController(PantusContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(TbAccount user)
        {
            if (user == null)
            {
                return NotFound();
            }
            var check = _context.TbAccounts
             .Where(m => m.Email == user.Email || m.Username == user.Username)
               .FirstOrDefault();

            if (check != null)
            {
                // Kiểm tra xem email hay username đã tồn tại
                if (check.Email == user.Email)
                {
                    Function._MessageEmail = "Email đã được sử dụng!";
                }
                else if (check.Username == user.Username)
                {
                    Function._MessageEmail = "Username đã được sử dụng!";
                }

                return RedirectToAction("Index", "Register");
            }

            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            user.RoleId = 2;
            user.LastLogin = DateTime.Now;
            _context.Add(user);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập!";
            return RedirectToAction("Index", "Login");
        }
    }
}
