using System;
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
    public class VatRatesController : AbstractAdminPolicyController
    {
        public VatRatesController(PrintoContextDB context) :base(context) { }

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
                vatRate.IsActive = true;
                vatRate.AddedDate = DateTime.Now;
                vatRate.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
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
                    vatRate.UpdatedDate = DateTime.Now;
                    vatRate.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
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

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.VatRates.FindAsync(id);
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
            var temp = await _context.VatRates.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool VatRateExists(int id)
        {
            return _context.VatRates.Any(e => e.VatRateID == id);
        }
    }
}
