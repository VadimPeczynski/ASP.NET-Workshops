using System;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.WebUI.Models
{
    public class SessionCart:Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product,quantity);
            Session.Set("Cart",this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session.Set("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var cart = session?.Get<SessionCart>("Cart")?? new SessionCart();
            cart.Session = session;
            return cart;
        }
    }
}
