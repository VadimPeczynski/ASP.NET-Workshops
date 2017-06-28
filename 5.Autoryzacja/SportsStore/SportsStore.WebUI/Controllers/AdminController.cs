using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductRepository _repo;

        public AdminController(IProductRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            return View(_repo.Products);
        }

        public IActionResult Create()
        {
            return View("Edit", new Product());
        }

        public IActionResult Edit(int productId)
        {
            return View(_repo.Products.FirstOrDefault(x=>x.ProductId==productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveProduct(product);
                TempData["message"] = $"{product.Name} zosta³ zapisany";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int productId)
        {
            var deletedProduct = _repo.DeleteProduct(productId);
            if (deletedProduct!=null)
            {
                TempData["message"] = $"{deletedProduct.Name} zosta³ usuniêty";

            }
            return RedirectToAction("Index");
        }
    }
}