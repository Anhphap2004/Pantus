using Microsoft.AspNetCore.Mvc;
using Pantus.Utilities;

namespace Pantus.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            TempData["SuccessMessage"] = "Đăng Xuất thành công. Vui lòng đăng nhập!";
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
    }
}
