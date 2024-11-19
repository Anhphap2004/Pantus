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
    public class EventsController : Controller
    {
        private readonly PantusContext _context;

        public EventsController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/Events
        public async Task<IActionResult> Index()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(await _context.TbEvents.ToListAsync());
        }

        // GET: Admin/Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbEvent = await _context.TbEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tbEvent == null)
            {
                return NotFound();
            }

            return View(tbEvent);
        }

        // GET: Admin/Events/Create
        public IActionResult Create()
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }

        // POST: Admin/Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Title,Description,Location,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Image,Details")] TbEvent tbEvent)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                _context.Add(tbEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbEvent);
        }

        // GET: Admin/Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbEvent = await _context.TbEvents.FindAsync(id);
            if (tbEvent == null)
            {
                return NotFound();
            }
            return View(tbEvent);
        }

        // POST: Admin/Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,Title,Description,Location,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive,Image,Details")] TbEvent tbEvent)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id != tbEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEventExists(tbEvent.EventId))
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
            return View(tbEvent);
        }

        // GET: Admin/Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.IsLogin())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbEvent = await _context.TbEvents
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (tbEvent == null)
            {
                return NotFound();
            }

            return View(tbEvent);
        }

        // POST: Admin/Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbEvent = await _context.TbEvents.FindAsync(id);
            if (tbEvent != null)
            {
                _context.TbEvents.Remove(tbEvent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbEventExists(int id)
        {
            return _context.TbEvents.Any(e => e.EventId == id);
        }
    }
}
