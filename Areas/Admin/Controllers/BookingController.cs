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
    public class BookingController : Controller
    {
        private readonly PantusContext _context;

        public BookingController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/Booking
        public async Task<IActionResult> Index()
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            return View(await _context.TbTables.ToListAsync());
        }

        // GET: Admin/Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbTable = await _context.TbTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (tbTable == null)
            {
                return NotFound();
            }

            return View(tbTable);
        }

        // GET: Admin/Booking/Create
        public IActionResult Create()
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            return View();
        }

        // POST: Admin/Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,TableNumber,Capacity,Status,IsActive,FullName,Phone,People,CreateDate,Hour")] TbTable tbTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbTable);
        }

        // GET: Admin/Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTable = await _context.TbTables.FindAsync(id);
            if (tbTable == null)
            {
                return NotFound();
            }
            return View(tbTable);
        }

        // POST: Admin/Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableId,TableNumber,Capacity,Status,IsActive,FullName,Phone,People,CreateDate,Hour")] TbTable tbTable)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (id != tbTable.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbTableExists(tbTable.TableId))
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
            return View(tbTable);
        }

        // GET: Admin/Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbTable = await _context.TbTables
                .FirstOrDefaultAsync(m => m.TableId == id);
            if (tbTable == null)
            {
                return NotFound();
            }

            return View(tbTable);
        }

        // POST: Admin/Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbTable = await _context.TbTables.FindAsync(id);
            if (tbTable != null)
            {
                _context.TbTables.Remove(tbTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbTableExists(int id)
        {
            return _context.TbTables.Any(e => e.TableId == id);
        }
    }
}
