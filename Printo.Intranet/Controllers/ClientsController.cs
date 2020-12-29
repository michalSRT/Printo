using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;
using Printo.Intranet.Controllers.Abstract;

namespace Printo.Intranet.Controllers
{
    public class ClientsController : AbstractPolicyController
    {
        public ClientsController(PrintoContext context) : base(context) {}

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.Clients.Include(c => c.AddedUser).Include(c => c.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.AddedUser)
                .Include(c => c.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientID,Name,CompanyFullName,NIP,Street,HouseNumber,AppartmentNumber,PostalCode,City,Email,Phone,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Client client)
        {
            if (ModelState.IsValid)
            {
                client.IsActive = true;
                client.AddedDate = DateTime.Now;
                client.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(client);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Klient: <br>" + client.Name + "<br> został dodany";
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.UpdatedUserID);
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var ClientOrders = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.IsActive == true && x.ClientID == id);

            ViewBag.ClientOrders = ClientOrders;
            ViewData["ClientOrders"] = ClientOrders;
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.UpdatedUserID);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientID,Name,CompanyFullName,NIP,Street,HouseNumber,AppartmentNumber,PostalCode,City,Email,Phone,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Client client)
        {
            if (id != client.ClientID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client.UpdatedDate = DateTime.Now;
                    client.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["msg"] = "Klient: <br>" + client.Name + "<br> został zmodyfikowany";
                return RedirectToAction(nameof(Index));
            }
            var ClientOrders = _context.Orders.Include(z=>z.ProductionStage).Where(x => x.IsActive == true && x.ClientID == id).ToList();
            ViewBag.ClientOrders = ClientOrders;
            ViewData["ClientOrders"] = ClientOrders;
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", client.UpdatedUserID);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.AddedUser)
                .Include(c => c.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ClientID == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Klient został trwale usunięty";

            return RedirectToAction(nameof(Index));
        }

        // POST: Clients/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            client.IsActive = false;
            client.UpdatedDate = DateTime.Now;
            client.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();
            TempData["msg"] = "Klient został usunięty";

            return RedirectToAction(nameof(Index));
        }

        // POST: Clients/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            client.IsActive = true;
            client.UpdatedDate = DateTime.Now;
            client.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();
            TempData["msg"] = "Klient został przywrócony";

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
