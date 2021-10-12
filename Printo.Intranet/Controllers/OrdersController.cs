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
using Printo.Intranet.Controllers.Abstract;

namespace Printo.Intranet.Controllers
{
    public class OrdersController : AbstractPolicyController
    {
        public OrdersController(PrintoContextDB context) : base(context) { }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            ViewData["ProductionStage"] = _context.ProductionStages.Where(x => x.IsActive == true).ToList();
            var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x =>x.ProductionStage.Name != "ARCHIWUM");
            return View(await printoContext.ToListAsync());
        }

        public async Task<IActionResult> FinishedOrders()
        {
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ProductionStage.Name == "ARCHIWUM");
            return View(await printoContext.ToListAsync());
        }        
        
        public async Task<IActionResult> ToInvoice()
        {
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ProductionStage.Name == "ARCHIWUM").Where(x=> x.InvoiceNumber == null);
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
            if (HttpContext.Session.GetString("UserTypeID") == "2") { return RedirectToAction("Index", "Home"); }
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients.Where(x=>x.IsActive == true), "ClientID", "Name");
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name");
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes.Where(x => x.IsActive == true), "DeliveryTypeID", "Name");
            ViewData["FinishingID"] = new SelectList(_context.Finishings.Where(x => x.IsActive == true), "FinishingID", "Name");
            ViewData["FormatID"] = new SelectList(_context.Formats.Where(x => x.IsActive == true), "FormatID", "Name");
            ViewData["MachineID"] = new SelectList(_context.Machines.Where(x => x.IsActive == true), "MachineID", "Name");
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes.Where(x => x.IsActive == true), "PaperTypeID", "Name");
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights.Where(x => x.IsActive == true), "PaperWeightID", "Grammature");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes.Where(x => x.IsActive == true), "PaymentTypeID", "Name");
            ViewData["PostPressID"] = new SelectList(_context.PostPresses.Where(x => x.IsActive == true), "PostPressID", "Name");
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors.Where(x => x.IsActive == true), "PrintColorID", "Name");
            ViewData["ProductID"] = new SelectList(_context.Products.Where(x => x.IsActive == true), "ProductID", "Name");
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages.Where(x => x.IsActive == true), "ProductionStageID", "Name");
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes.Where(x => x.IsActive == true), "SheetSizeID", "Name");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["VatRateID"] = new SelectList(_context.VatRates.Where(x => x.IsActive == true), "VatRateID", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails,InvoiceNumber")] Order order)

        {
            if (ModelState.IsValid)
            {
                order.IsActive = true;
                order.AddedDate = DateTime.Now;
                order.AddedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                _context.Add(order);
                await _context.SaveChangesAsync();

                var client = _context.Clients.Where(y => y.ClientID == order.ClientID).FirstOrDefault();
                var format = _context.Formats.Where(x => x.FormatID == order.FormatID).FirstOrDefault();
                var paper = _context.PaperTypes.Where(x => x.PaperTypeID == order.PaperTypeID).FirstOrDefault();
                var paperWeight = _context.PaperWeights.Where(x => x.PaperWeightID == order.PaperWeightID).FirstOrDefault();
                var sheetSize = _context.SheetSizes.Where(x => x.SheetSizeID == order.SheetSizeID).FirstOrDefault();
                var printColor = _context.PrintColors.Where(x => x.PrintColorID == order.PrintColorID).FirstOrDefault();

                _context.Events.Add(new Event
                    {
                        Title = client.Name + " - " + order.OrderName + " | " + sheetSize.Name + " | " + printColor.Name,
                        Start = DateTime.Today.AddHours(7.0),
                        End = null,
                        AllDay = true,
                        OrderID = order.OrderID,
                        BackgroundColor = "#3ad29f",
                        Description = format.Name + " | " + paper.Name + " | " + paperWeight.Grammature + " | " + "Nakład: " + order.Quantity + " | " + order.Description + " | " + order.Comments
                    });
                
                    
                await _context.SaveChangesAsync();

                Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało dodane";

                return RedirectToAction("Index", "Home");
            }
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients.Where(x => x.IsActive == true), "ClientID", "Name");
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name");
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes.Where(x => x.IsActive == true), "DeliveryTypeID", "Name");
            ViewData["FinishingID"] = new SelectList(_context.Finishings.Where(x => x.IsActive == true), "FinishingID", "Name");
            ViewData["FormatID"] = new SelectList(_context.Formats.Where(x => x.IsActive == true), "FormatID", "Name");
            ViewData["MachineID"] = new SelectList(_context.Machines.Where(x => x.IsActive == true), "MachineID", "Name");
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes.Where(x => x.IsActive == true), "PaperTypeID", "Name");
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights.Where(x => x.IsActive == true), "PaperWeightID", "Grammature");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes.Where(x => x.IsActive == true), "PaymentTypeID", "Name");
            ViewData["PostPressID"] = new SelectList(_context.PostPresses.Where(x => x.IsActive == true), "PostPressID", "Name");
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors.Where(x => x.IsActive == true), "PrintColorID", "Name");
            ViewData["ProductID"] = new SelectList(_context.Products.Where(x => x.IsActive == true), "ProductID", "Name");
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages.Where(x => x.IsActive == true), "ProductionStageID", "Name");
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes.Where(x => x.IsActive == true), "SheetSizeID", "Name");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["VatRateID"] = new SelectList(_context.VatRates.Where(x => x.IsActive == true), "VatRateID", "Name");
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            var UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients.Where(x => x.IsActive == true), "ClientID", "Name");
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2 ), "UserID", "Name");
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes.Where(x => x.IsActive == true), "DeliveryTypeID", "Name");
            ViewData["FinishingID"] = new SelectList(_context.Finishings.Where(x => x.IsActive == true), "FinishingID", "Name");
            ViewData["FormatID"] = new SelectList(_context.Formats.Where(x => x.IsActive == true), "FormatID", "Name");
            ViewData["MachineID"] = new SelectList(_context.Machines.Where(x => x.IsActive == true), "MachineID", "Name");
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes.Where(x => x.IsActive == true), "PaperTypeID", "Name");
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights.Where(x => x.IsActive == true), "PaperWeightID", "Grammature");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes.Where(x => x.IsActive == true), "PaymentTypeID", "Name");
            ViewData["PostPressID"] = new SelectList(_context.PostPresses.Where(x => x.IsActive == true), "PostPressID", "Name");
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors.Where(x => x.IsActive == true), "PrintColorID", "Name");
            ViewData["ProductID"] = new SelectList(_context.Products.Where(x => x.IsActive == true), "ProductID", "Name");
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages.Where(x => x.IsActive == true), "ProductionStageID", "Name");
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes.Where(x => x.IsActive == true), "SheetSizeID", "Name");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["VatRateID"] = new SelectList(_context.VatRates.Where(x => x.IsActive == true), "VatRateID", "Name");
            ViewData["ProductionStage"] = _context.ProductionStages.Where(x => x.IsActive == true).ToList();

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails,InvoiceNumber")] Order order)
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
                    if(order.ProductionStageID == 5)
                    {
                        order.PrintDateTime = DateTime.Now;
                        order.PrintUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
                    }
                    _context.Update(order);
                    Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                    var format = _context.Formats.Where(x => x.FormatID == order.FormatID).FirstOrDefault();
                    var paper = _context.PaperTypes.Where(x => x.PaperTypeID == order.PaperTypeID).FirstOrDefault();
                    var paperWeight = _context.PaperWeights.Where(x => x.PaperWeightID == order.PaperWeightID).FirstOrDefault();
                    var sheetSize = _context.SheetSizes.Where(x => x.SheetSizeID == order.SheetSizeID).FirstOrDefault();
                    var printColor = _context.PrintColors.Where(x => x.PrintColorID == order.PrintColorID).FirstOrDefault();
                    TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało zmodyfikowane";
                    // kod poniżej do naprarwy
                    var v = _context.Events.Where(a => a.OrderID == order.OrderID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Title = clientName.Name + " - " + order.OrderName + " | " + sheetSize.Name + " | " + printColor.Name;
                        v.Description = format.Name + " | " + paper.Name + " | " + paperWeight.Grammature + " | " + "Nakład: " + order.Quantity + " | " + order.Description + " | " + order.Comments;

                        if (order.ProductionStageID >= 5)
                        {
                            v.BackgroundColor = "gray";
                        }
                        if (order.ProductionStageID == 4)
                        {
                            v.BackgroundColor = "#FF5722";
                        }
                        if (order.ProductionStageID < 4)
                        {
                            v.BackgroundColor = "#3ad29f";
                        }
                        _context.Events.Update(v);
                        _context.SaveChanges();
                    }

                await _context.SaveChangesAsync();

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

                if(order.ProductionStageID == 8)
                {
                    return RedirectToAction("FinishedOrders", "Orders");
                }
                return RedirectToAction("Index", "Orders");
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
            if (HttpContext.Session.GetString("UserTypeID") == "2") { return RedirectToAction("Index", "Home"); }

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();
            ViewData["AddedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["ClientID"] = new SelectList(_context.Clients.Where(x => x.IsActive == true), "ClientID", "Name");
            ViewData["PrintUserID"] = new SelectList(_context.Users.Where(z => z.UserTypeID == 2), "UserID", "Name");
            ViewData["DeliveryTypeID"] = new SelectList(_context.DeliveryTypes.Where(x => x.IsActive == true), "DeliveryTypeID", "Name");
            ViewData["FinishingID"] = new SelectList(_context.Finishings.Where(x => x.IsActive == true), "FinishingID", "Name");
            ViewData["FormatID"] = new SelectList(_context.Formats.Where(x => x.IsActive == true), "FormatID", "Name");
            ViewData["MachineID"] = new SelectList(_context.Machines.Where(x => x.IsActive == true), "MachineID", "Name");
            ViewData["PaperTypeID"] = new SelectList(_context.PaperTypes.Where(x => x.IsActive == true), "PaperTypeID", "Name");
            ViewData["PaperWeightID"] = new SelectList(_context.PaperWeights.Where(x => x.IsActive == true), "PaperWeightID", "Grammature");
            ViewData["PaymentTypeID"] = new SelectList(_context.PaymentTypes.Where(x => x.IsActive == true), "PaymentTypeID", "Name");
            ViewData["PostPressID"] = new SelectList(_context.PostPresses.Where(x => x.IsActive == true), "PostPressID", "Name");
            ViewData["PrintColorID"] = new SelectList(_context.PrintColors.Where(x => x.IsActive == true), "PrintColorID", "Name");
            ViewData["ProductID"] = new SelectList(_context.Products.Where(x => x.IsActive == true), "ProductID", "Name");
            ViewData["ProductionStageID"] = new SelectList(_context.ProductionStages.Where(x => x.IsActive == true), "ProductionStageID", "Name");
            ViewData["SheetSizeID"] = new SelectList(_context.SheetSizes.Where(x => x.IsActive == true), "SheetSizeID", "Name");
            ViewData["UpdatedUserID"] = new SelectList(_context.Users, "UserID", "Login");
            ViewData["VatRateID"] = new SelectList(_context.VatRates.Where(x => x.IsActive == true), "VatRateID", "Name");

            TempData["msg"] = "Skopiowano dane do nowego zamówienia";

            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CopyAndCreate(int id, [Bind("OrderID,ClientID,DeliveryTypeID,FinishingID,FormatID,MachineID,PaperWeightID,PaperTypeID,PaymentTypeID,PostPressID,PrintColorID,ProductID,ProductionStageID,SheetSizeID,VatRateID,StartDate,EndDate,OrderName,Description,NetPrice,IsReprint,Quantity,SheetsNumber,SheetsNumberPrinted,Comments,IsActive,AddedDate,UpdatedDate,AddedUserID,UpdatedUserID,PrintUserID,PrintDateTime,PaymentDetails,DeliveryDetails,InvoiceNumber")] Order order)
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

                var client = _context.Clients.Where(y => y.ClientID == order.ClientID).FirstOrDefault();
                var format = _context.Formats.Where(x => x.FormatID == order.FormatID).FirstOrDefault();
                var paper = _context.PaperTypes.Where(x => x.PaperTypeID == order.PaperTypeID).FirstOrDefault();
                var paperWeight = _context.PaperWeights.Where(x => x.PaperWeightID == order.PaperWeightID).FirstOrDefault();
                var sheetSize = _context.SheetSizes.Where(x => x.SheetSizeID == order.SheetSizeID).FirstOrDefault();
                var printColor = _context.PrintColors.Where(x => x.PrintColorID == order.PrintColorID).FirstOrDefault();
                _context.Events.Add(new Event
                {                
                    Title = client.Name + " - " + order.OrderName + " | " + sheetSize.Name + " | " + printColor.Name,
                    Start = DateTime.Today.AddHours(7.0),
                    End = null,
                    AllDay = true,
                    OrderID = order.OrderID,
                    BackgroundColor = "#3ad29f",
                    Description = format.Name + " | " + paper.Name + " | " + paperWeight.Grammature + " | " + "Nakład: " + order.Quantity + " | " + order.Description + " | " + order.Comments
                });
                await _context.SaveChangesAsync();

                Client clientName = _context.Clients.Where(o => o.ClientID == order.ClientID).FirstOrDefault();
                TempData["msg"] = "Zamówienie: <br>" + clientName.Name + " - " + order.OrderName + "<br> zostało dodane";

                return RedirectToAction("Index", "Home");
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
            if (HttpContext.Session.GetString("UserTypeID") == "2") { return RedirectToAction("Index", "Home"); }

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

        [HttpGet("ChangeProductionStage")]
        public async Task<IActionResult> ChangeProductionStage(int id, int prodId)
        {
            var temp = await _context.Orders.FindAsync(id);
            temp.ProductionStageID = prodId;
            temp.UpdatedDate = DateTime.Now;
            temp.UpdatedUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            if (temp.ProductionStageID == 5)
            {
                temp.PrintDateTime = DateTime.Now;
                temp.PrintUserID = Int32.Parse(HttpContext.Session.GetString("UserID"));
            }
            await _context.SaveChangesAsync();
            TempData["msg"] = "Zmieniono etap produkcyjny.";
            // kod poniżej do naprarwy
            var v = _context.Events.Where(a => a.OrderID == temp.OrderID).FirstOrDefault();

            if (v != null)
            {
                if (temp.ProductionStageID >= 5)
                {
                    v.BackgroundColor = "gray";
                }
                if (temp.ProductionStageID == 4)
                {
                    v.BackgroundColor = "#FF5722";
                }
                if (temp.ProductionStageID < 4)
                {
                    v.BackgroundColor = "#3ad29f";
                }
                _context.Events.Update(v);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Orders");
        }

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

        [HttpGet("Index")]
        public async Task<IActionResult> Index(int id)
        {
            ViewData["ProductionStage"] = _context.ProductionStages.Where(x => x.IsActive == true && x.Name != "ARCHIWUM").ToList();
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "ARCHIWUM").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            ViewBag.InvoiceCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name == "ARCHIWUM" && x.InvoiceNumber == null).Count();

            if (id != 0)
            {
                var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ProductionStage.ProductionStageID == id);
                return View(await printoContext.ToListAsync());
            }
            else
            {
                var printoContext = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ProductionStage.Name != "ARCHIWUM");
                return View(await printoContext.ToListAsync());
            }
        }
    }
}
