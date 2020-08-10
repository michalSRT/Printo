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
    public class DeliveryTypesController : Controller
    {
        private readonly PrintoContext _context;

        public DeliveryTypesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: DeliveryTypes
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.DeliveryTypes.Include(d => d.AddedUser).Include(d => d.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: DeliveryTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryType = await _context.DeliveryTypes
                .Include(d => d.AddedUser)
                .Include(d => d.UpdatedUser)
                .FirstOrDefaultAsync(m => m.DeliveryTypeID == id);
            if (deliveryType == null)
            {
                return NotFound();
            }

            return View(deliveryType);
        }

        // GET: DeliveryTypes/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: DeliveryTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryTypeID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] DeliveryType deliveryType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.UpdatedUserID);
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryType = await _context.DeliveryTypes.FindAsync(id);
            if (deliveryType == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.UpdatedUserID);
            return View(deliveryType);
        }

        // POST: DeliveryTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryTypeID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] DeliveryType deliveryType)
        {
            if (id != deliveryType.DeliveryTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryTypeExists(deliveryType.DeliveryTypeID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryType.UpdatedUserID);
            return View(deliveryType);
        }

        // GET: DeliveryTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryType = await _context.DeliveryTypes
                .Include(d => d.AddedUser)
                .Include(d => d.UpdatedUser)
                .FirstOrDefaultAsync(m => m.DeliveryTypeID == id);
            if (deliveryType == null)
            {
                return NotFound();
            }

            return View(deliveryType);
        }

        // POST: DeliveryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryType = await _context.DeliveryTypes.FindAsync(id);
            _context.DeliveryTypes.Remove(deliveryType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryTypeExists(int id)
        {
            return _context.DeliveryTypes.Any(e => e.DeliveryTypeID == id);
        }
    }
}
