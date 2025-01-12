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
    public class ServicesController : Controller
    {
        private readonly PantusContext _context;

        public ServicesController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/Services
        public async Task<IActionResult> Index()
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            return View(await _context.TbServices.ToListAsync());
        }

        // GET: Admin/Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbService = await _context.TbServices
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (tbService == null)
            {
                return NotFound();
            }

            return View(tbService);
        }

        // GET: Admin/Services/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,Title,Description,Image,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Icon")] TbService tbService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbService);
        }

        // GET: Admin/Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbService = await _context.TbServices.FindAsync(id);
            if (tbService == null)
            {
                return NotFound();
            }
            return View(tbService);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,Title,Description,Image,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Icon")] TbService tbService)
        {
            if (id != tbService.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbServiceExists(tbService.ServiceId))
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
            return View(tbService);
        }

        // GET: Admin/Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbService = await _context.TbServices
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (tbService == null)
            {
                return NotFound();
            }

            return View(tbService);
        }

        // POST: Admin/Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbService = await _context.TbServices.FindAsync(id);
            if (tbService != null)
            {
                _context.TbServices.Remove(tbService);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbServiceExists(int id)
        {
            return _context.TbServices.Any(e => e.ServiceId == id);
        }
    }
}
