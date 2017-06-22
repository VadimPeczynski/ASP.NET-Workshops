using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly Cart _cart;
        public OrderController(IOrderRepository repoService, Cart cartService)
        {
            _repository = repoService;
            _cart = cartService;
        }

        public ViewResult List() =>
            View(_repository.Orders.Where(o => !o.Shipped));
        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Order order = _repository.Orders
                .FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Shipped = true;
                _repository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Order());
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Twój koszyk jest pusty!");
            }
            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            _cart.Clear();
            return View();
        }
    }
}