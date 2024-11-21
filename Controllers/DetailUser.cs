using Microsoft.AspNetCore.Mvc;
using Pantus.Utilities;
using Pantus.Models;
namespace Pantus.Controllers
{
    public class DetailUser : Controller
    {
        public IActionResult Detail()
        {
            return View();
        }
    }
}
