using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;

namespace Printo.Intranet.Controllers
{
    public class VatRatesController : Controller
    {
        private readonly PrintoContext _context;

        public VatRatesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: VatRates
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.VatRates.Include(v => v.AddedUser).Include(v => v.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: VatRates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRate = await _context.VatRates
                .Include(v => v.AddedUser)
                .Include(v => v.UpdatedUser)
                .FirstOrDefaultAsync(m => m.VatRateID == id);
            if (vatRate == null)
            {
                return NotFound();
            }

            return View(vatRate);
        }

        // GET: VatRates/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: VatRates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VatRateID,Name,Rate,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] VatRate vatRate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vatRate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.UpdatedUserID);
            return View(vatRate);
        }

        // GET: VatRates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRate = await _context.VatRates.FindAsync(id);
            if (vatRate == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.UpdatedUserID);
            return View(vatRate);
        }

        // POST: VatRates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VatRateID,Name,Rate,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] VatRate vatRate)
        {
            if (id != vatRate.VatRateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vatRate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VatRateExists(vatRate.VatRateID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", vatRate.UpdatedUserID);
            return View(vatRate);
        }

        // GET: VatRates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vatRate = await _context.VatRates
                .Include(v => v.AddedUser)
                .Include(v => v.UpdatedUser)
                .FirstOrDefaultAsync(m => m.VatRateID == id);
            if (vatRate == null)
            {
                return NotFound();
            }

            return View(vatRate);
        }

        // POST: VatRates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vatRate = await _context.VatRates.FindAsync(id);
            _context.VatRates.Remove(vatRate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VatRateExists(int id)
        {
            return _context.VatRates.Any(e => e.VatRateID == id);
        }
    }
}
