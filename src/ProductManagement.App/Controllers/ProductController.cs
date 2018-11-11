using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.App.Models;
using ProductManagement.Domain.Products.Repository;

namespace ProductManagement.App.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();

            var productsViewModel = products.Select(product => new ProductViewModel(product));

            return View(productsViewModel);
        }

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        [Route("api/Product/ClearAll")]
        public IActionResult Clear()
        {
            _productRepository.RemoveAll();

            return Ok();
        }
    }
}
