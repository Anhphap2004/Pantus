using Microsoft.AspNetCore.Mvc;
using Pantus.Models;
using Pantus.Utilities;
using Pantus.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;
namespace Pantus.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        
        private readonly PantusContext _context;
        public LoginController(PantusContext context)
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

            if(user == null)
            {
                return NotFound();
            }    
            string pw = Function.MD5Password(user.Password);
            var check = _context.TbAccounts.Where(m => (m.Username == user.Username) && (m.Password == pw)).FirstOrDefault();
            if (check == null) 
            {
                Function._Message = "Lỗi Tên Đăng Nhập hoặc Mật Khẩu";
                return RedirectToAction("Index", "Login");

            }
            Function._Message = string.Empty;
            Function._AccountId =  check.AccountId;
            Function._Username = string.IsNullOrEmpty(check.Username) ? string.Empty : check.Username;
            Function._Email = string.IsNullOrEmpty(check.Email) ? string.Empty : check.Email;
            return RedirectToAction("index", "Home");
        }
        
    }
}
