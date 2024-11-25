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
    public class MenuDishController : Controller
    {
        private readonly PantusContext _context;

        public int Tabnine { get; private set; }

        public MenuDishController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/MenuDish
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            var pantusContext = _context.TbMenuItems.Include(t => t.Category);
            return View(await pantusContext.ToListAsync());
        }

        // GET: Admin/MenuDish/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuItem = await _context.TbMenuItems
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (tbMenuItem == null)
            {
                return NotFound();
            }

            return View(tbMenuItem);
        }

        // GET: Admin/MenuDish/Create
        public IActionResult Create()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            ViewData["CategoryId"] = new SelectList(_context.TbMenuCategories, "CategoryId", "Title");
            return View();
        }

        // POST: Admin/MenuDish/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuItemId,Title,Alias,Description,Price,Image,CategoryId,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,PriceSale,Quantity,Star,Detail")] TbMenuItem tbMenuItem)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                 if (tbMenuItem.Title != null)//+
                {//+
                    tbMenuItem.Alias = Pantus.Utilities.Function.TitleSlugGenerationAlias(tbMenuItem.Title);//+
                }//+
                _context.Add(tbMenuItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TbMenuCategories, "CategoryId", "CategoryId", tbMenuItem.CategoryId);
            return View(tbMenuItem);
        }

        // GET: Admin/MenuDish/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuItem = await _context.TbMenuItems.FindAsync(id);
            if (tbMenuItem == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TbMenuCategories, "CategoryId", "Title", tbMenuItem.CategoryId);
            return View(tbMenuItem);
        }

        // POST: Admin/MenuDish/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuItemId,Title,Alias,Description,Price,Image,CategoryId,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,PriceSale,Quantity,Star,Detail")] TbMenuItem tbMenuItem)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id != tbMenuItem.MenuItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMenuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMenuItemExists(tbMenuItem.MenuItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TbMenuCategories, "CategoryId", "CategoryId", tbMenuItem.CategoryId);
            return View(tbMenuItem);
        }

        // GET: Admin/MenuDish/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuItem = await _context.TbMenuItems
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.MenuItemId == id);
            if (tbMenuItem == null)
            {
                return NotFound();
            }

            return View(tbMenuItem);
        }

        // POST: Admin/MenuDish/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMenuItem = await _context.TbMenuItems.FindAsync(id);
            if (tbMenuItem != null)
            {
                _context.TbMenuItems.Remove(tbMenuItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMenuItemExists(int id)
        {
            return _context.TbMenuItems.Any(e => e.MenuItemId == id);
        }
    }
}
