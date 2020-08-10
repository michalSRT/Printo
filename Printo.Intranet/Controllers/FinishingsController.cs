﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;

namespace Printo.Intranet.Controllers
{
    public class FinishingsController : Controller
    {
        private readonly PrintoContext _context;

        public FinishingsController(PrintoContext context)
        {
            _context = context;
        }

        // GET: Finishings
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.Finishings.Include(f => f.AddedUser).Include(f => f.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: Finishings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishing = await _context.Finishings
                .Include(f => f.AddedUser)
                .Include(f => f.UpdatedUser)
                .FirstOrDefaultAsync(m => m.FinishingID == id);
            if (finishing == null)
            {
                return NotFound();
            }

            return View(finishing);
        }

        // GET: Finishings/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: Finishings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FinishingID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Finishing finishing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finishing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.UpdatedUserID);
            return View(finishing);
        }

        // GET: Finishings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishing = await _context.Finishings.FindAsync(id);
            if (finishing == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.UpdatedUserID);
            return View(finishing);
        }

        // POST: Finishings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FinishingID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Finishing finishing)
        {
            if (id != finishing.FinishingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finishing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinishingExists(finishing.FinishingID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", finishing.UpdatedUserID);
            return View(finishing);
        }

        // GET: Finishings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finishing = await _context.Finishings
                .Include(f => f.AddedUser)
                .Include(f => f.UpdatedUser)
                .FirstOrDefaultAsync(m => m.FinishingID == id);
            if (finishing == null)
            {
                return NotFound();
            }

            return View(finishing);
        }

        // POST: Finishings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finishing = await _context.Finishings.FindAsync(id);
            _context.Finishings.Remove(finishing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinishingExists(int id)
        {
            return _context.Finishings.Any(e => e.FinishingID == id);
        }
    }
}