using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public int PageSize { get; set; }
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            PageSize = 4;
        }

        public ViewResult List(string category,int page=1)
        {
            var model = new ProductsListViewModel
            {
                Products = _productRepository.Products
                .Where(p=>category==null||p.Category==category)
                    .OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category==null?
                    _productRepository.Products.Count() :
                    _productRepository.Products.Count(e => e.Category==category)
                },
                CurrentCategory = category
            };
            return View(model);
        }

        //[HttpPost]
        //public RedirectToActionResult List(int productId, string returnUrl)
        //{
        //    var product = _repository.Products.FirstOrDefault(p => p.ProductId == productId);
        //    if (product != null)
        //    {
        //        GetCart().AddItem(product, 1);
        //    }
        //    return RedirectToAction(@"Cart\Index", new { returnUrl });
        //}

    }
}