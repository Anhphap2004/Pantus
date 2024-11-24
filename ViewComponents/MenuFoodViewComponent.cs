using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pantus.Models;

namespace Pantus.ViewComponents
{
    public class MenuFoodViewComponent : ViewComponent
    {
        private readonly PantusContext _context;

        public MenuFoodViewComponent(PantusContext context)
        {
            _context = context;
        }

        //public async Task<IViewComponentResult> InvokeAsync()
        //{
        //    var items = await _context.TbMenuItems
        //        .Where(m => m.IsActive) 
        //        .ToListAsync();
        //    return View(items); 
        //}

        public async Task<IViewComponentResult> InvokeAsync(int? categoryId = null)
        {
            // Lấy tất cả sản phẩm nếu categoryId là null
            var products = categoryId == null
                ? await _context.TbMenuItems.ToListAsync()
                : await _context.TbMenuItems.Where(p => p.CategoryId == categoryId).ToListAsync();

            return View(products);
        }
    }
}
