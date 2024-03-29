﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;
using Printo.Intranet.Controllers.Abstract;

namespace Printo.Intranet.Controllers
{
    public class PaperWeightsController : AbstractAdminPolicyController
    {
        public PaperWeightsController(PrintoContextDB context) : base(context) { }

        // GET: PaperWeights
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.PaperWeights.Include(p => p.AddedUser).Include(p => p.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: PaperWeights/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperWeight = await _context.PaperWeights
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PaperWeightID == id);
            if (paperWeight == null)
            {
                return NotFound();
            }

            return View(paperWeight);
        }

        // GET: PaperWeights/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: PaperWeights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaperWeightID,Grammature,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PaperWeight paperWeight)
        {
            if (ModelState.IsValid)
            {
                paperWeight.IsActive = true;
                paperWeight.AddedDate = DateTime.Now;
                paperWeight.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(paperWeight);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.UpdatedUserID);
            return View(paperWeight);
        }

        // GET: PaperWeights/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperWeight = await _context.PaperWeights.FindAsync(id);
            if (paperWeight == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.UpdatedUserID);
            return View(paperWeight);
        }

        // POST: PaperWeights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaperWeightID,Grammature,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PaperWeight paperWeight)
        {
            if (id != paperWeight.PaperWeightID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paperWeight.UpdatedDate = DateTime.Now;
                    paperWeight.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(paperWeight);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaperWeightExists(paperWeight.PaperWeightID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", paperWeight.UpdatedUserID);
            return View(paperWeight);
        }

        // GET: PaperWeights/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paperWeight = await _context.PaperWeights
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PaperWeightID == id);
            if (paperWeight == null)
            {
                return NotFound();
            }

            return View(paperWeight);
        }

        // POST: PaperWeights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paperWeight = await _context.PaperWeights.FindAsync(id);
            _context.PaperWeights.Remove(paperWeight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.PaperWeights.FindAsync(id);
            temp.IsActive = false;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var temp = await _context.PaperWeights.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PaperWeightExists(int id)
        {
            return _context.PaperWeights.Any(e => e.PaperWeightID == id);
        }
    }
}
