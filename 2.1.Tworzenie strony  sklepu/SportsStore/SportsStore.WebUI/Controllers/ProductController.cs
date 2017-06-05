using Microsoft.AspNetCore.Mvc;
using SportsStore.Domain.Abstract;
using System.Linq;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            PageSize = 4;
        }

        public int PageSize { get; private set; }

        public IActionResult List(int page=1)
        {
            return View(_productRepository.Products.OrderBy(x=>x.ProductId).Skip((page-1)*PageSize).Take(PageSize));
        }
    }
}