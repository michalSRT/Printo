using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Printo.Data.Data;
using Printo.Intranet.Controllers.Abstract;
using Printo.Intranet.Models;

namespace Printo.Intranet.Controllers
{
    public class StatisticsController : AbstractPolicyController
    {
        public StatisticsController(PrintoContext context) : base(context) { }

        public IActionResult Index()
        {

            var orders = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.IsActive == true);

            ViewBag.OrdersNumber = orders.Where(x => x.ProductionStage.Name != "KONIEC").Count();
            ViewBag.FinishedOrdersNumber = orders.Where(x => x.ProductionStage.Name == "KONIEC").Count();
            ViewBag.ProductsNumber = _context.Products.Where(x => x.IsActive == true).Count();
            ViewBag.ClientsNumber = _context.Clients.Where(x => x.IsActive == true).Count();

            var masterModel = new HomeIndexVM();

            var barChartData = GetBarChartData();
            masterModel.BarChartData = barChartData;

            return View(masterModel);
        }

        private BarChartVM GetBarChartData()
        {
            var orders = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser);
            var products = _context.Products.ToList();

            var barChartData = new BarChartVM();

            var labels = new List<string>();
            
            barChartData.labels = labels;

            var datasets = new List<BarChartChildVM>();
            
            var childModel = new BarChartChildVM();

            childModel.label = "Ilość zamówień";
            childModel.backgroundColor = @"rgba(58, 210, 159, 0.2)";
            childModel.borderColor = "#3ad29f";
            childModel.borderWidth = 1;
            childModel.hoverBackgroundColor = @"rgba(58, 210, 159, 0.8)";
            childModel.hoverBorderColor = "#3ad29f";

            var dataList = new List<int>();

            foreach (Product p in products)
            {
                labels.Add(p.Name);
                dataList.Add(orders.Where(x => x.ProductID == p.ProductID).Count());
            }

            childModel.data = dataList;

            datasets.Add(childModel);

            barChartData.datasets = datasets;

            return barChartData;
        }

        //private BarChartVM GetBarChartDataForClient(int? clientID)
        //{
        //    var orders = _context.Orders.Include(o => o.AddedUser).Include(o => o.Client).Include(o => o.DeliveryType).Include(o => o.Finishing).Include(o => o.Format).Include(o => o.Machine).Include(o => o.PaperType).Include(o => o.PaperWeight).Include(o => o.PaymentType).Include(o => o.PostPress).Include(o => o.PrintColor).Include(o => o.Product).Include(o => o.ProductionStage).Include(o => o.SheetSize).Include(o => o.UpdatedUser).Include(o => o.VatRate).Include(o => o.PrintUser).Where(x => x.ClientID == clientID);
        //    var products = _context.Products.ToList();

        //    var barChartData = new BarChartVM();

        //    var labels = new List<string>();

        //    barChartData.labels = labels;

        //    var datasets = new List<BarChartChildVM>();

        //    var childModel = new BarChartChildVM();

        //    childModel.label = "Ilość zamówień";
        //    childModel.backgroundColor = @"rgba(58, 210, 159, 0.2)";
        //    childModel.borderColor = "#3ad29f";
        //    childModel.borderWidth = 1;
        //    childModel.hoverBackgroundColor = @"rgba(58, 210, 159, 0.8)";
        //    childModel.hoverBorderColor = "#3ad29f";

        //    var dataList = new List<int>();

        //    foreach (Product p in products)
        //    {
        //        labels.Add(p.Name);
        //        dataList.Add(orders.Where(x => x.ProductID == p.ProductID).Count());
        //    }

        //    childModel.data = dataList;

        //    datasets.Add(childModel);

        //    barChartData.datasets = datasets;

        //    return barChartData;
        //}

    }
}
