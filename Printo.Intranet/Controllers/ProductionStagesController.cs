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
    public class ProductionStagesController : Controller
    {
        private readonly PrintoContext _context;

        public ProductionStagesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: ProductionStages
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.ProductionStages.Include(p => p.AddedUser).Include(p => p.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: ProductionStages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStage = await _context.ProductionStages
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ProductionStageID == id);
            if (productionStage == null)
            {
                return NotFound();
            }

            return View(productionStage);
        }

        // GET: ProductionStages/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: ProductionStages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductionStageID,Name,Color,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] ProductionStage productionStage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productionStage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", productionStage.UpdatedUserID);
            return View(productionStage);
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

        // GET: ProductionStages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionStage = await _context.ProductionStages
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ProductionStageID == id);
            if (productionStage == null)
            {
                return NotFound();
            }

            return View(productionStage);
        }

        // POST: ProductionStages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionStage = await _context.ProductionStages.FindAsync(id);
            _context.ProductionStages.Remove(productionStage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionStageExists(int id)
        {
            return _context.ProductionStages.Any(e => e.ProductionStageID == id);
        }
    }
}
