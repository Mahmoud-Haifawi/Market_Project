using Market_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Market_Project.Controllers
{
    public class AdminDashboardController : Controller
    {
        private readonly ModelContext _Context;
        public AdminDashboardController(ModelContext Context)
        {
            _Context = Context;
        }

        public IActionResult Index()
        {
            var item = _Context.User1s.Count();
            var item1 = _Context.Category1s.Count();
            var item2 = _Context.Products.Count();
            var item3 = _Context.Order1s.Count();
            //var item4 = _Context.Products.Max(x => x.Propricse);
            //var item5 = _Context.Products.Min(x => x.Propricse);
            //var item6 = _Context.Order1s.Sum(x => x.Total);




            ViewBag.noofusers = item;
            ViewBag.noofcategory = item1;
            ViewBag.noofproducts = item2;
            ViewBag.noofOrders = item3;
            //ViewBag.MaxOfProduct = item4;
            //ViewBag.MinOfProudct= item5;
            //ViewBag.SumOfOrders = item6;



            return View();
        }
    }
}
