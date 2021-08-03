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
    public class ToDoesController : AbstractPolicyController
    {
        public ToDoesController(PrintoContext context): base(context) { }

        // GET: ToDoes
        public async Task<IActionResult> Index()
        {
            var printoContext = _context.ToDos.Include(t => t.AddedUser).Include(t => t.UpdatedUser).Include(t => t.User).OrderBy(t => t.Date);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Name");
            return View(await printoContext.ToListAsync());
        }

        // GET: ToDoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.AddedUser)
                .Include(t => t.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ToDoID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDoes/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["UserID"] = new SelectList(_context.Users.Where(x=>x.IsActive == true), "UserID", "Name");
            return View();
        }

        // POST: ToDoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToDoID,Name,Description,Date,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,UserID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                toDo.IsActive = true;
                toDo.AddedDate = DateTime.Now;
                toDo.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                TempData["msg"] = "Notatka 'Do zrobienia' została dodana";

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.UpdatedUserID);
            return View(toDo);
        }

        // GET: ToDoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.UpdatedUserID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Name", toDo.UserID);

            return View(toDo);
        }

        // POST: ToDoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToDoID,Name,Description,Date,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,UserID")] ToDo toDo)
        {
            if (id != toDo.ToDoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    toDo.UpdatedDate = DateTime.Now;
                    toDo.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.ToDoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["msg"] = "Notatka 'Do zrobienia' została zmodyfikowana";

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.AddedUserID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", toDo.UpdatedUserID);
            ViewData["UserID"] = new SelectList(_context.Users, "UserID", "Name", toDo.UserID);
            return View(toDo);
        }

        // GET: ToDoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .Include(t => t.AddedUser)
                .Include(t => t.UpdatedUser)
                .FirstOrDefaultAsync(m => m.ToDoID == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Notatka 'Do zrobienia' została trwale usunięta";

            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.ToDos.FindAsync(id);
            temp.IsActive = false;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();
            TempData["msg"] = "Notatka 'Do zrobienia' została usunięta";

            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var temp = await _context.ToDos.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            await _context.SaveChangesAsync();
            TempData["msg"] = "Notatka 'Do zrobienia' została przywrócona";

            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoID == id);
        }
    }
}
