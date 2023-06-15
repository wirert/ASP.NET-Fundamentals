using Microsoft.AspNetCore.Mvc;
using SMS.Models.Products;
using SMS.Services.Contracts;

namespace SMS.Controllers
{
    public class ProductsController : Controller
    {
        public readonly IProductsService productsService;

        public ProductsController(IProductsService _productsService)
        {
            productsService = _productsService;
        }

        public IActionResult Create()
        {
            var model = new CreateProductViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productsService.AddNewProductAsync(model);

            return RedirectToAction("Index", "Home");
        }
    }
}
