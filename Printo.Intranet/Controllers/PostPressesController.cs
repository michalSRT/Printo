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
    public class PostPressesController : Controller
    {
        private readonly PrintoContext _context;

        public PostPressesController(PrintoContext context)
        {
            _context = context;
        }

        // GET: PostPresses
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            var printoContext = _context.PostPresses.Include(p => p.AddedUser).Include(p => p.UpdatedUser);
            return View(await printoContext.ToListAsync());
        }

        // GET: PostPresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postPress = await _context.PostPresses
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PostPressID == id);
            if (postPress == null)
            {
                return NotFound();
            }

            return View(postPress);
        }

        // GET: PostPresses/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            return View();
        }

        // POST: PostPresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostPressID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PostPress postPress)
        {
            if (ModelState.IsValid)
            {
                postPress.IsActive = true;
                postPress.AddedDate = DateTime.Now;
                _context.Add(postPress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.UpdatedUserID);
            return View(postPress);
        }

        // GET: PostPresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postPress = await _context.PostPresses.FindAsync(id);
            if (postPress == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.UpdatedUserID);
            return View(postPress);
        }

        // POST: PostPresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostPressID,Name,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] PostPress postPress)
        {
            if (id != postPress.PostPressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    postPress.UpdatedDate = DateTime.Now;
                    _context.Update(postPress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostPressExists(postPress.PostPressID))
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
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", postPress.UpdatedUserID);
            return View(postPress);
        }

        // GET: PostPresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postPress = await _context.PostPresses
                .Include(p => p.AddedUser)
                .Include(p => p.UpdatedUser)
                .FirstOrDefaultAsync(m => m.PostPressID == id);
            if (postPress == null)
            {
                return NotFound();
            }

            return View(postPress);
        }

        // POST: PostPresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postPress = await _context.PostPresses.FindAsync(id);
            _context.PostPresses.Remove(postPress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.PostPresses.FindAsync(id);
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
            var temp = await _context.PostPresses.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool PostPressExists(int id)
        {
            return _context.PostPresses.Any(e => e.PostPressID == id);
        }
    }
}
