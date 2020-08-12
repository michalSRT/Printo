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
    public class FormatsController : Controller
    {
        private readonly PrintoContext _context;

        public FormatsController(PrintoContext context)
        {
            _context = context;
        }

        // GET: Formats
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.Formats.Include(f => f.AddedUser).Include(f => f.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: Formats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _context.Formats
                .Include(f => f.AddedUser)
                .Include(f => f.UpdatedUser)
                .FirstOrDefaultAsync(m => m.FormatID == id);
            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }

        // GET: Formats/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: Formats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormatID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Format format)
        {
            if (ModelState.IsValid)
            {
                _context.Add(format);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.UpdatedUserID);
            return View(format);
        }

        // GET: Formats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _context.Formats.FindAsync(id);
            if (format == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.UpdatedUserID);
            return View(format);
        }

        // POST: Formats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormatID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Format format)
        {
            if (id != format.FormatID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(format);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormatExists(format.FormatID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", format.UpdatedUserID);
            return View(format);
        }

        // GET: Formats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var format = await _context.Formats
                .Include(f => f.AddedUser)
                .Include(f => f.UpdatedUser)
                .FirstOrDefaultAsync(m => m.FormatID == id);
            if (format == null)
            {
                return NotFound();
            }

            return View(format);
        }

        // POST: Formats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var format = await _context.Formats.FindAsync(id);
            _context.Formats.Remove(format);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormatExists(int id)
        {
            return _context.Formats.Any(e => e.FormatID == id);
        }
    }
}
