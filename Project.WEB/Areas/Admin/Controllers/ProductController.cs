using Microsoft.AspNetCore.Mvc;
using Project.BLL.Services;
using Project.Entity.Models;
using System.Linq;

namespace Project.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        public IActionResult Index()
        {
            TempData["Title"] = "Odalar";
            var products = _productService.GetAll().ToList();
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.CreateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
