using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Printo.Data.Data;
using Printo.Intranet.Models;
using Microsoft.AspNetCore.Http;
using Printo.Intranet.Controllers.Abstract;

namespace Printo.Intranet.Controllers
{
    public class HomeController : AbstractPolicyController
    {
        public HomeController(PrintoContext context) : base(context) { }

        public IActionResult Index()
        {
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewData["OrderID"] = new SelectList(_context.Orders.Where(o => o.ProductionStage.Name != "ARCHIWUM"), "OrderID", "ConcatDescription");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetAllEvents()
        {
            var events = _context.Events.Select(e => new
            {
                id = e.EventID,
                title = e.Title,
                description = e.Description,
                start = e.Start,
                end = e.End,
                color = e.BackgroundColor,
                allDay = e.AllDay,
                orderID = e.OrderID
            }).ToList();
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderName");
            return new JsonResult(events);
        }

        [HttpPost]
        public IActionResult SaveEvent(Event e)
        {
            var status = false;

            if (e.EventID > 0)
            {
                var v = _context.Events.Where(a => a.EventID == e.EventID).FirstOrDefault();
                if (v != null)
                {
                    v.Title = e.Title;
                    v.Start = e.Start;
                    v.End = e.End;
                    if (e.Description != null)
                    {
                        v.Description = e.Description;
                    }
                    v.AllDay = e.AllDay;
                    if (e.OrderID != null)
                    {
                        v.OrderID = e.OrderID;
                    }
                    if (e.BackgroundColor != null)
                    {
                        v.BackgroundColor = e.BackgroundColor;
                    }
                }
            }
            else
            {
                _context.Events.Add(e);
            }
            _context.SaveChanges();
            status = true;
            ViewData["OrderID"] = new SelectList(_context.Orders, "OrderID", "OrderName");
            return new JsonResult(status);
        }

        [HttpPost]
        public IActionResult DeleteEvent(int eventID)
        {
            var status = false;

            var v = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();
            if (v != null)
            {
                _context.Events.Remove(v);
                _context.SaveChanges();
                status = true;
            }
            return new JsonResult(status);
        }

        [HttpPost]
        public IActionResult ChangeColor(int eventID, string color)
        {
            var status = false;
            var v = _context.Events.Where(a => a.EventID == eventID).FirstOrDefault();
            if (v != null)
            {
                v.BackgroundColor = color;
                _context.Events.Update(v);
                _context.SaveChanges();
                status = true;
            }
            return new JsonResult(status);
        }
    }
}
