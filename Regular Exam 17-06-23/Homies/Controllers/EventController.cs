using Homies.Models.Event;
using Homies.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : BaseController
    {
        private readonly IEventService eventService;

        public EventController(IEventService _eventService)
        {
            eventService = _eventService;
        }

        public async Task<IActionResult> All()
        {
            var models = await eventService.GetAllEventsAsync();

            return View(models);
        }

        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            if (userId == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var models = await eventService.GetJoinedEventsAsync(userId);

            return View(models);
        }

        public async Task<IActionResult> Add()
        {
            var models = new AddEventViewModel()
            {
                Types = await eventService.GetTypesAsync(),
                CreatedOn = DateTime.Now
            };

            return View(models);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            model.Types = await eventService.GetTypesAsync();
            model.CreatedOn = DateTime.Now;

            if (!ModelState.IsValid)
            {

                return View(model);
            }

            if (model.Start < model.CreatedOn)
            {
                ModelState.AddModelError("Start", "Start date can't be before creation date");

                return View(model);
            }

            if (model.End < model.Start)
            {
                ModelState.AddModelError("End", "End date can't be before Start date");

                return View(model);
            }

            try
            {
                var userId = GetUserId();

                await eventService.AddEventAsync(userId, model);

                return RedirectToAction("All", "Event");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var types = await eventService.GetTypesAsync();

            var model = await eventService.FindEventByIdAsync(id);



            if (model == null)
            {
                return RedirectToAction("All");
            }

            model.Types = types;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }

            if (model.Start < model.CreatedOn)
            {
                ModelState.AddModelError("Start", "Start date can't be before creation date");

                return View(model);
            }

            if (model.End < model.Start)
            {
                ModelState.AddModelError("End", "End date can't be before Start date");

                return View(model);
            }

            try
            {
                var userId = GetUserId();

                await eventService.EditEventAsync(model);

                return RedirectToAction("All", "Event");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong!");

                return View(model);
            }
        }

        public async Task<IActionResult> Join(int id)
        {
            var userId = GetUserId();

            try
            {
                await eventService.JoinAsync(userId, id);

                return RedirectToAction("Joined");
            }
            catch (Exception)
            {

                return RedirectToAction("All");
            }
        }

        //public async Task<IActionResult> Leave(int id)
        //{
        //    var userId = GetUserId();


        //}
    }
}
