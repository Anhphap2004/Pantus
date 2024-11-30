using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;
using Pantus.Utilities;

namespace Pantus.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            return View();
        }

        public Task<IActionResult> Logout()
        {
            // Logic xử lý logout
            Function._AccountId = 0;
            Function._Message = string.Empty;
            Function._MessageEmail = string.Empty;
            Function._Email = string.Empty;
            Function._Username = string.Empty;
            Function._FullName = string.Empty;
            Function._Phone = string.Empty;
            TempData["SuccessMessage"] = "Đăng Xuất thành công. Vui lòng đăng nhập!";
            return Task.FromResult<IActionResult>(RedirectToAction("Index", "Home"));
        }

    }
}
