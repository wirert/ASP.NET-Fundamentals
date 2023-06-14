using BusStation.Models;
using BusStation.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BusStation.Controllers
{
    public class DestinationsController : BaseController
    {
        private readonly IDestinationService destinationService;

        public DestinationsController(IDestinationService _destinationService)
        {
            destinationService = _destinationService;
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new AddDestinationViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDestinationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Date < DateTime.Now)
            {
                ModelState.AddModelError(nameof(model.Date), "The Date can not be before the current date");

                return View(model);
            }

            try
            {
                await destinationService.AddAsync(model);

                return RedirectToAction("All", "Destinations");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }            
        }

        public async Task<IActionResult> All()
        {
            var models = await destinationService.GetAllDestinationsAsync();

            return View(models);
        }
    }
}
