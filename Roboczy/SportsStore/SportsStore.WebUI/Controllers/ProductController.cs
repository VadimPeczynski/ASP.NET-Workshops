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
    }
}