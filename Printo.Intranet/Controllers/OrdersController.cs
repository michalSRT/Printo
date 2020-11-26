using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;

namespace Printo.Intranet.Controllers
{
    public class OrdersController : Controller
    {
        private readonly PrintoContext _context;

        public OrdersController(PrintoContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x =>x.ProductionStage.Name != "KONIEC");
            return View(await printoContext.ToListAsync());
        }

        public async Task<IActionResult> FinishedOrders()
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ProductionStage.Name == "KONIEC");
            return View(await printoContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.AddedUser)
                .Include(o => o.Client)
                .Include(o => o.DeliveryType)
                .Include(o => o.Finishing)
                .Include(o => o.Format)
                .Include(o => o.Machine)
                .Include(o => o.PaperType)
                .Include(o => o.PaperWeight)
                .Include(o => o.PaymentType)
                .Include(o => o.PostPress)
                .Include(o => o.PrintColor)
                .Include(o => o.Product)
                .Include(o => o.ProductionStage)
                .Include(o => o.SheetSize)
                .Include(o => o.UpdatedUser)
                .Include(o => o.VatRate)
                .Include(o => o.PrintUser)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name");
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name");
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name");
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name");
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name");
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name");
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name");
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name");
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name");
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name");
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name");
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.IsActive = true;
                order.AddedDate = DateTime.Now;
                order.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(order);
                await _context.SaveChangesAsync();

                var ord = _context.Orders.Where(x => x.OrderName == order.OrderName).FirstOrDefault();
                var client = _context.Clients.Where(y => y.ClientID == order.ClientID).FirstOrDefault();

                _context.Events.Add(new Event { 
                    Title = client.Name + " - " + order.OrderName,
                    Start = DateTime.Today.AddHours(7.0),
                    End = null,
                    AllDay = true,
                    OrderID = ord.OrderID,
                    BackgroundColor = "#3ad29f",
                    Description = order.Description
                });
                _context.SaveChanges();

                Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało dodane";

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name", order.ClientID);
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name", order.PrintUserID);
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name", order.DeliveryTypeID);
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name", order.FinishingID);
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name", order.FormatID);
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name", order.MachineID);
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name", order.PaperTypeID);
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature", order.PaperWeightID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name", order.PaymentTypeID);
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name", order.PostPressID);
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name", order.PrintColorID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", order.ProductID);
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name", order.ProductionStageID);
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name", order.SheetSizeID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.UpdatedUserID);
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name", order.VatRateID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name", order.ClientID);
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name", order.PrintUserID);
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name", order.DeliveryTypeID);
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name", order.FinishingID);
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name", order.FormatID);
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name", order.MachineID);
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name", order.PaperTypeID);
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature", order.PaperWeightID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name", order.PaymentTypeID);
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name", order.PostPressID);
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name", order.PrintColorID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", order.ProductID);
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name", order.ProductionStageID);
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name", order.SheetSizeID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.UpdatedUserID);
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name", order.VatRateID);
            
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    order.UpdatedDate = DateTime.Now;
                    order.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    _context.Update(order);
                    Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                    TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało zmodyfikowane";
                    await _context.SaveChangesAsync();

                    var v = _context.Events.Where(a => a.OrderID == order.OrderID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Title = order.Client.Name + " - " + order.OrderName;
                        v.Description = order.Description;
                        if(order.ProductionStageID == 5 || order.ProductionStageID == 6 || order.ProductionStageID == 7 || order.ProductionStageID == 8)
                        {
                            v.BackgroundColor = "#6c757d";
                        }
                        _context.SaveChanges();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
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

            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "ClientID", order.ClientID);
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name", order.PrintUserID);
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name", order.DeliveryTypeID);
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name", order.FinishingID);
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name", order.FormatID);
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name", order.MachineID);
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name", order.PaperTypeID);
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature", order.PaperWeightID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name", order.PaymentTypeID);
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name", order.PostPressID);
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name", order.PrintColorID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", order.ProductID);
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name", order.ProductionStageID);
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name", order.SheetSizeID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.UpdatedUserID);
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name", order.VatRateID);

            return View(order);
            
        }

        // GET: Orders/CopyAndCreate/5
        public async Task<IActionResult> CopyAndCreate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name", order.ClientID);
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name", order.PrintUserID);
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name", order.DeliveryTypeID);
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name", order.FinishingID);
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name", order.FormatID);
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name", order.MachineID);
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name", order.PaperTypeID);
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature", order.PaperWeightID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name", order.PaymentTypeID);
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name", order.PostPressID);
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name", order.PrintColorID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", order.ProductID);
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name", order.ProductionStageID);
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name", order.SheetSizeID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.UpdatedUserID);
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name", order.VatRateID);

            TempData["msg"] = "Skopiowano dane do nowego zamówienia";

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CopyAndCreate(int id, [Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                order.IsActive = true;
                order.AddedDate = DateTime.Now;
                order.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(order);
                await _context.SaveChangesAsync();

                var ord = _context.Orders.Where(x => x.OrderName == order.OrderName).FirstOrDefault();
                var client = _context.Clients.Where(y => y.ClientID == order.ClientID).FirstOrDefault();

                _context.Events.Add(new Event
                {
                    Title = client.Name + " - " + order.OrderName,
                    Start = DateTime.Today.AddHours(7.0),
                    End = null,
                    AllDay = true,
                    OrderID = ord.OrderID,
                    BackgroundColor = "#3ad29f",
                    Description = order.Description
                });
                _context.SaveChanges();

                Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało dodane";

                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.AddedUserID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "Name", order.ClientID);
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name", order.PrintUserID);
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes, "DeliveryTypeID", "Name", order.DeliveryTypeID);
            ViewData["FinishingID"] = new SelectList(_context.Finishings, "FinishingID", "Name", order.FinishingID);
            ViewData["FormatID"] = new SelectList(_context.Formats, "FormatID", "Name", order.FormatID);
            ViewData["MachineID"] = new SelectList(_context.Machines, "MachineID", "Name", order.MachineID);
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes, "PaperTypeID", "Name", order.PaperTypeID);
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights, "PaperWeightID", "Grammature", order.PaperWeightID);
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes, "PaymentTypeID", "Name", order.PaymentTypeID);
            ViewData["PostPressID"] = new SelectList(_context.PostPresses, "PostPressID", "Name", order.PostPressID);
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors, "PrintColorID", "Name", order.PrintColorID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Name", order.ProductID);
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages, "ProductionStageID", "Name", order.ProductionStageID);
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes, "SheetSizeID", "Name", order.SheetSizeID);
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login", order.UpdatedUserID);
            ViewData["VatRateID"] = new SelectList(_context.VatRates, "VatRateID", "Name", order.VatRateID);
            return View(order);
        }


        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.AddedUser)
                .Include(o => o.Client)
                .Include(o => o.DeliveryType)
                .Include(o => o.Finishing)
                .Include(o => o.Format)
                .Include(o => o.Machine)
                .Include(o => o.PaperType)
                .Include(o => o.PaperWeight)
                .Include(o => o.PaymentType)
                .Include(o => o.PostPress)
                .Include(o => o.PrintColor)
                .Include(o => o.Product)
                .Include(o => o.ProductionStage)
                .Include(o => o.SheetSize)
                .Include(o => o.UpdatedUser)
                .Include(o => o.VatRate)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            TempData["msg"] = "Zamówienie zostało trwale usunięte";
            return RedirectToAction(nameof(Index));
        }

        // POST: Patient/Deactivate/5
        [HttpPost, ActionName("Deactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeactivateConfirmed(int id)
        {
            var temp = await _context.Orders.FindAsync(id);
            temp.IsActive = false;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            var e = _context.Events.Where(a => a.OrderID == id).FirstOrDefault();
            if (e != null)
            {

                _context.Remove(e);
                _context.SaveChanges();
            }
            await _context.SaveChangesAsync();
            TempData["msg"] = "Zamówienie zostało usunięte";
            return RedirectToAction(nameof(Index));
        }

        // POST: Admin/Restore/5
        [HttpPost, ActionName("Restore")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RestoreConfirmed(int id)
        {
            var temp = await _context.Orders.FindAsync(id);
            temp.IsActive = true;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));

            var ord = _context.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            var client = _context.Clients.Where(y => y.ClientID == ord.ClientID).FirstOrDefault();

            _context.Events.Add(new Event
            {
                Title = client.Name + " - " + ord.OrderName,
                Start = DateTime.Today.AddHours(7.0),
                End = null,
                AllDay = true,
                OrderID = ord.OrderID,
                BackgroundColor = "#3ad29f",
                Description = ord.Description
            });
            _context.SaveChanges();

            await _context.SaveChangesAsync();
            TempData["msg"] = "Zamówienie zostało przywrócone";

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderID == id);
        }

        public IActionResult AddClient(int OrderID)
        {
            ViewBag.OrderID = OrderID;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(int? OrderID, [Bind("ClientID,Name,CompanyFullName,NIP,Street,HouseNumber,AppartmentNumber,PostalCode,City,Email,Phone,Description,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID")] Client client)
        {

                client.IsActive = true;
                client.AddedDate = DateTime.Now;
                _context.Add(client);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "Orders", new { id = OrderID });

        }

        public async Task<IActionResult> PrintOrder(int? id)
        {
            if (HttpContext.Session.GetString("UserID") == null) { return RedirectToAction("Index", "Login"); }

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.AddedUser)
                .Include(o => o.Client)
                .Include(o => o.DeliveryType)
                .Include(o => o.Finishing)
                .Include(o => o.Format)
                .Include(o => o.Machine)
                .Include(o => o.PaperType)
                .Include(o => o.PaperWeight)
                .Include(o => o.PaymentType)
                .Include(o => o.PostPress)
                .Include(o => o.PrintColor)
                .Include(o => o.Product)
                .Include(o => o.ProductionStage)
                .Include(o => o.SheetSize)
                .Include(o => o.UpdatedUser)
                .Include(o => o.VatRate)
                .Include(o => o.PrintUser)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}
