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
    public class MenuCategoriesController : Controller
    {
        private readonly PantusContext _context;

        public MenuCategoriesController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/MenuCategories
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(await _context.TbMenuCategories.ToListAsync());
        }

        // GET: Admin/MenuCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuCategory = await _context.TbMenuCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbMenuCategory == null)
            {
                return NotFound();
            }

            return View(tbMenuCategory);
        }

        // GET: Admin/MenuCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MenuCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Title,Alias,Description,Image,IsActive")] TbMenuCategory tbMenuCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMenuCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMenuCategory);
        }

        // GET: Admin/MenuCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuCategory = await _context.TbMenuCategories.FindAsync(id);
            if (tbMenuCategory == null)
            {
                return NotFound();
            }
            return View(tbMenuCategory);
        }

        // POST: Admin/MenuCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,Title,Alias,Description,Image,IsActive")] TbMenuCategory tbMenuCategory)
        {
            if (id != tbMenuCategory.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMenuCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMenuCategoryExists(tbMenuCategory.CategoryId))
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
            return View(tbMenuCategory);
        }

        // GET: Admin/MenuCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMenuCategory = await _context.TbMenuCategories
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (tbMenuCategory == null)
            {
                return NotFound();
            }

            return View(tbMenuCategory);
        }

        // POST: Admin/MenuCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMenuCategory = await _context.TbMenuCategories.FindAsync(id);
            if (tbMenuCategory != null)
            {
                _context.TbMenuCategories.Remove(tbMenuCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMenuCategoryExists(int id)
        {
            return _context.TbMenuCategories.Any(e => e.CategoryId == id);
        }
    }
}
