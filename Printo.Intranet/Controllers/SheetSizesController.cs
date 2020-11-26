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
    public class SheetSizesController : Controller
    {
        private readonly PrintoContext _context;

        public SheetSizesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: SheetSizes
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            var printoContext = _context.SheetSizes.Include(s => s.AddedUser).Include(s => s.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: SheetSizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheetSize = await _context.SheetSizes
                .Include(s => s.AddedUser)
                .Include(s => s.UpdatedUser)
                .FirstOrDefaultAsync(m => m.SheetSizeID == id);
            if (sheetSize == null)
            {
                return NotFound();
            }

            return View(sheetSize);
        }

        // GET: SheetSizes/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: SheetSizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SheetSizeID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] SheetSize sheetSize)
        {
            if (ModelState.IsValid)
            {
                sheetSize.IsActive = true;
                sheetSize.AddedDate = DateTime.Now;
                sheetSize.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(sheetSize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.UpdatedUserID);
            return View(sheetSize);
        }

        // GET: SheetSizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheetSize = await _context.SheetSizes.FindAsync(id);
            if (sheetSize == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.UpdatedUserID);
            return View(sheetSize);
        }

        // POST: SheetSizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SheetSizeID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] SheetSize sheetSize)
        {
            if (id != sheetSize.SheetSizeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    sheetSize.UpdatedDate = DateTime.Now;
                    sheetSize.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(sheetSize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SheetSizeExists(sheetSize.SheetSizeID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", sheetSize.UpdatedUserID);
            return View(sheetSize);
        }

        // GET: SheetSizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sheetSize = await _context.SheetSizes
                .Include(s => s.AddedUser)
                .Include(s => s.UpdatedUser)
                .FirstOrDefaultAsync(m => m.SheetSizeID == id);
            if (sheetSize == null)
            {
                return NotFound();
            }

            return View(sheetSize);
        }

        // POST: SheetSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sheetSize = await _context.SheetSizes.FindAsync(id);
            _context.SheetSizes.Remove(sheetSize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.SheetSizes.FindAsync(id);
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
            var temp = await _context.SheetSizes.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool SheetSizeExists(int id)
        {
            return _context.SheetSizes.Any(e => e.SheetSizeID == id);
        }
    }
}
