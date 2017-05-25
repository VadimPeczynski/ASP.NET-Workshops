using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        private Product myProduct = new Product()
        {
            Name = "Auto",
            Price = 275M
        };

        public IActionResult Index()
        {
            return View(myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return View(myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscounter = false;
            ViewBag.Supplier = null;
            ViewBag.Product = myProduct;

            return View(myProduct);
        }

        public ActionResult DemoArray()
        {
            Product[] array =
            {
                new Product {Name = "Kajak", Price = 300M},
                new Product {Name = "£ódka", Price = 1000M}
            };
            return View(array);
        }
    }
}