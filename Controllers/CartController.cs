using Microsoft.AspNetCore.Mvc;

namespace Pantus.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
