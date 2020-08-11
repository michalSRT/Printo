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
    public class DeliveryAdressesController : Controller
    {
        private readonly PrintoContext _context;

        public DeliveryAdressesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: DeliveryAdresses
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.DeliveryAdresses.Include(d => d.AddedUser).Include(d => d.Client).Include(d => d.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: DeliveryAdresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAdress = await _context.DeliveryAdresses
                .Include(d => d.AddedUser)
                .Include(d => d.Client)
                .Include(d => d.UpdatedUser)
                .FirstOrDefaultAsync(m => m.DeliveryAdressID == id);
            if (deliveryAdress == null)
            {
                return NotFound();
            }

            return View(deliveryAdress);
        }

        // GET: DeliveryAdresses/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: DeliveryAdresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryAdressID,ContactName,CompanyName,Phone,Street,HouseNumber,AppartmentNumber,PostalCode,City,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,ClientID")] DeliveryAdress deliveryAdress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryAdress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", deliveryAdress.ClientID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.UpdatedUserID);
            return View(deliveryAdress);
        }

        // GET: DeliveryAdresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAdress = await _context.DeliveryAdresses.FindAsync(id);
            if (deliveryAdress == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", deliveryAdress.ClientID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.UpdatedUserID);
            return View(deliveryAdress);
        }

        // POST: DeliveryAdresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryAdressID,ContactName,CompanyName,Phone,Street,HouseNumber,AppartmentNumber,PostalCode,City,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,ClientID")] DeliveryAdress deliveryAdress)
        {
            if (id != deliveryAdress.DeliveryAdressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryAdress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryAdressExists(deliveryAdress.DeliveryAdressID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", deliveryAdress.ClientID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", deliveryAdress.UpdatedUserID);
            return View(deliveryAdress);
        }

        // GET: DeliveryAdresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryAdress = await _context.DeliveryAdresses
                .Include(d => d.AddedUser)
                .Include(d => d.Client)
                .Include(d => d.UpdatedUser)
                .FirstOrDefaultAsync(m => m.DeliveryAdressID == id);
            if (deliveryAdress == null)
            {
                return NotFound();
            }

            return View(deliveryAdress);
        }

        // POST: DeliveryAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deliveryAdress = await _context.DeliveryAdresses.FindAsync(id);
            _context.DeliveryAdresses.Remove(deliveryAdress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryAdressExists(int id)
        {
            return _context.DeliveryAdresses.Any(e => e.DeliveryAdressID == id);
        }
    }
}
