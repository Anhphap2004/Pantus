﻿using System;
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
    public class AccountsController : Controller
    {
        private readonly PantusContext _context;

        public AccountsController(PantusContext context)
        {
            _context = context;
        }

        // GET: Admin/Accounts
        public async Task<IActionResult> Index()
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            var pantusContext = _context.TbAccounts.Include(t => t.Role);
            return View(await pantusContext.ToListAsync());
        }

        // GET: Admin/Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbAccount = await _context.TbAccounts
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (tbAccount == null)
            {
                return NotFound();
            }

            return View(tbAccount);
        }

        // GET: Admin/Accounts/Create
        public IActionResult Create()
        {
            // Lấy danh sách các vai trò từ database và tạo SelectListItem
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleName");
            return View();
        }


        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,Username,Password,FullName,Phone,Email,RoleId,LastLogin,Image,IsActive")] TbAccount tbAccount)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (ModelState.IsValid)
            {
                _context.Add(tbAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId", tbAccount.RoleId);
            return View(tbAccount);
        }

        // GET: Admin/Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbAccount = await _context.TbAccounts.FindAsync(id);
            if (tbAccount == null)
            {
                return NotFound();
            }

            // Tạo SelectList với RoleName thay vì RoleId
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleName", tbAccount.RoleId);
            return View(tbAccount);
        }


        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Username,Password,FullName,Phone,Email,RoleId,LastLogin,Image,IsActive")] TbAccount tbAccount)
        {
            if (id != tbAccount.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbAccountExists(tbAccount.AccountId))
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
            ViewData["RoleId"] = new SelectList(_context.TbRoles, "RoleId", "RoleId", tbAccount.RoleId);
            return View(tbAccount);
        }

        // GET: Admin/Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!Function.CanAccessAdminPage())
                return RedirectToAction("Index", "Login");
            if (id == null)
            {
                return NotFound();
            }

            var tbAccount = await _context.TbAccounts
                .Include(t => t.Role)
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (tbAccount == null)
            {
                return NotFound();
            }

            return View(tbAccount);
        }

        // POST: Admin/Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbAccount = await _context.TbAccounts.FindAsync(id);
            if (tbAccount != null)
            {
                _context.TbAccounts.Remove(tbAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbAccountExists(int id)
        {
            return _context.TbAccounts.Any(e => e.AccountId == id);
        }
    }

}
