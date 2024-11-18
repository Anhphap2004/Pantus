using Microsoft.AspNetCore.Mvc;
using Pantus.Models;
namespace Pantus.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        [Area("Admin")]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        
    }
}
