using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Printo.Data.Data;
using Printo.Intranet.Models;

namespace Printo.Intranet.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly PrintoContext _context;

        public HomeController(PrintoContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewBag.OrdersCount = _context.Orders.Where(x => x.IsActive == true && x.ProductionStage.Name != "KONIEC").Count();
            ViewBag.ToDoesCount = _context.ToDos.Where(x => x.IsActive == true).Count();
            return View();
            //return View();
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
