using Microsoft.AspNetCore.Mvc;
using SMS.Services.Contracts;

namespace SMS.Controllers
{
    public class CartsController : BaseController
    {
        public readonly ICartsService cartsService;

        public CartsController(ICartsService _cartsService)
        {
            cartsService = _cartsService;
        }

        public async Task<IActionResult> AddProduct(string productId)
        {
            try
            {
                var userId = GetUserId();

                await cartsService.AddToCartAsync(userId, productId);

                return RedirectToAction("Details");
            }
            catch (ArgumentException ae)
            {
                ViewBag.ErrorMessage = ae.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Details()
        {
            try
            {
                var userId = GetUserId();

                var models = await cartsService.GetCartDetailsAsync(userId);

                return View(models);
            }
            catch (ArgumentException ae)
            {
                ViewBag.ErrorMessage = ae.Message;

                return RedirectToAction("Error", "Home");
            }
        }

        public async Task<IActionResult> Buy()
        {
			try
			{
				var userId = GetUserId();

				await cartsService.BuyAsync(userId);

				return RedirectToAction("Index", "Home");
			}
			catch (ArgumentException ae)
			{
				ViewBag.ErrorMessage = ae.Message;

				return RedirectToAction("Error", "Home");
			}
		}
	}
}
