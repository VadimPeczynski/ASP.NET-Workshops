using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private readonly Cart _cartService;

        public CartSummaryViewComponent(Cart cartService)
        {
            _cartService = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cartService);
        }
    }
}
