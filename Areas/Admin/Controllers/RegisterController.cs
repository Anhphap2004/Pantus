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
            var check = _context.TbAccounts.Where(m => m.Email == user.Email).FirstOrDefault();
            if (check != null)
            {
                Function._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }
            Function._MessageEmail = string.Empty;
            user.Password = Function.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Đăng ký thành công. Vui lòng đăng nhập!";
            return RedirectToAction("Index", "Login");
        }
    }
}
