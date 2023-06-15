using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Services.Contracts;
using System.Diagnostics;

namespace SMS.Controllers
{
    public class HomeController : BaseController
    {
        public readonly IProductsService productsService;

        public HomeController(IProductsService _productsService)
        {
            productsService = _productsService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("IndexLoggedIn");
            }

            return View();
        }

        public async Task<IActionResult> IndexLoggedIn()
        {
            ViewBag.UserName = GetUserName();

            var models = await productsService.GetAllAsync();

            return View(models);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            string errorMessage = ViewBag.ErrorMessage;

            return View(new ErrorViewModel {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ,
                Message = errorMessage
            });
        }
    }
}