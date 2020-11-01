using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;

namespace Printo.Intranet.Controllers
{
    public class PrintColorsController : Controller
    {
        private readonly PrintoContext _context;

        public PrintColorsController(PrintoContext context)
        {
            _context = context;
        }

        // GET: PrintColors
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            var printoContext = _context.PrintColors.Include(p => p.AddedUser).Include(p => p.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: PrintColors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printColor = await _context.PrintColors
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PrintColorID == id);
            if (printColor == null)
            {
                return NotFound();
            }

            return View(printColor);
        }

        // GET: PrintColors/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: PrintColors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrintColorID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PrintColor printColor)
        {
            if (ModelState.IsValid)
            {
                printColor.IsActive = true;
                printColor.AddedDate = DateTime.Now;
                _context.Add(printColor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.UpdatedUserID);
            return View(printColor);
        }

        // GET: PrintColors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printColor = await _context.PrintColors.FindAsync(id);
            if (printColor == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.UpdatedUserID);
            return View(printColor);
        }

        // POST: PrintColors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrintColorID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PrintColor printColor)
        {
            if (id != printColor.PrintColorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    printColor.UpdatedDate = DateTime.Now;
                    _context.Update(printColor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrintColorExists(printColor.PrintColorID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", printColor.UpdatedUserID);
            return View(printColor);
        }

        // GET: PrintColors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printColor = await _context.PrintColors
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PrintColorID == id);
            if (printColor == null)
            {
                return NotFound();
            }

            return View(printColor);
        }

        // POST: PrintColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printColor = await _context.PrintColors.FindAsync(id);
            _context.PrintColors.Remove(printColor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.PrintColors.FindAsync(id);
            temp.IsActive = false;
            temp.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var temp = await _context.PrintColors.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PrintColorExists(int id)
        {
            return _context.PrintColors.Any(e => e.PrintColorID == id);
        }
    }
}
