using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebShopDemo.Core.Contracts;
using WebShopDemo.Core.Models;

namespace WebShopDemo.Controllers
{
    /// <summary>
    /// Web shop products
    /// </summary>
    [Authorize]    
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        /// <summary>
        /// Constructor for productcontroller
        /// </summary>
        /// <param name="_productService">service from IoC</param>
        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        /// <summary>
        /// Show all products
        /// </summary>
        /// <returns>View with all active products</returns>
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var result = await productService.GetAllAsync();

            ViewBag.Title = "Products";

            return View(result);
        }

        /// <summary>
        /// Buy product 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Buy(Guid id, int count)
        {
           await productService.UpdateProductAsync(id, count);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Redirect to form for add product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ProductViewModel();

            ViewBag.Title = "Add new product";

            return View(model);
        }

        /// <summary>
        /// Add new or update product
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View with all active products</returns>
        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            ViewBag.Title = "Add new product";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Get product and add quantity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddQuantity(Guid id, int count)
        {
            await productService.AddQuantityAsync(id, count);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Remove product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await productService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
