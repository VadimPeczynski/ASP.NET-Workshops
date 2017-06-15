using System.Linq;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;

        public CartController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string returnUrl)
        {
            var model = new CartIndexViewModel{Cart = GetCart(),ReturnUrl = returnUrl};
            return View(model);
        }
        
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            var product = _repository.Products.FirstOrDefault(p=>p.ProductId==productId);
            if (product!=null)
            {
                var cart = GetCart();
                cart.AddItem(product, 1);
                HttpContext.Session.Set("Cart", cart);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart()
        {
            var cart = HttpContext.Session.Get<Cart>("Cart");
            if (cart==null)
            {
                cart = new Cart();
                HttpContext.Session.Set("Cart", cart);
            }
            return cart;
        }
    }
}