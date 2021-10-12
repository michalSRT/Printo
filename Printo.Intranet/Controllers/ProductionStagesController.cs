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
    public class ProductionStagesController : AbstractAdminPolicyController
    {
        public ProductionStagesController(PrintoContextDB context) : base(context) { }

        // GET: ProductionStages
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.ProductionStages.Include(p => p.AddedUser).Include(p => p.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: ProductionStages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStage = await _context.ProductionStages.FindAsync(id);
            if (productionStage == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.UpdatedUserID);
            return View(productionStage);
        }

        // POST: ProductionStages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductionStageID,Name,Color,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] ProductionStage productionStage)
        {
            if (id != productionStage.ProductionStageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productionStage.UpdatedDate = DateTime.Now;
                    productionStage.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(productionStage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionStageExists(productionStage.ProductionStageID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.UpdatedUserID);
            return View(productionStage);
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.ProductionStages.FindAsync(id);
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
            var temp = await _context.ProductionStages.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ProductionStageExists(int id)
        {
            return _context.ProductionStages.Any(e => e.ProductionStageID == id);
        }
    }
}
