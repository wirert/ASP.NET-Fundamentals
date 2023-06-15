using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

using BusStation.Models;
using BusStation.Services.Contracts;

namespace BusStation.Controllers
{
    public class TicketsController : BaseController
    {
        private readonly ITicketService ticketService;

        public TicketsController(ITicketService _ticketService)
        {
            ticketService = _ticketService;
        }

        public IActionResult Create(int destinationId)
        {
            var model = new CreateTicketsViewModel()
            { 
                DestinationId = destinationId 
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await ticketService.CreateAsync(model);

                return RedirectToAction("All", "Destinations");
            }
            catch (ArgumentException ae)
            {
                ModelState.AddModelError("", ae.Message);

                return View(model);
            }            
        }

        public async Task<IActionResult> Reserve(int destinationId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                await ticketService.BookAsync(userId, destinationId);

                return RedirectToAction("MyTickets", "Tickets");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);

                return RedirectToAction("All", "Destinations");
            }
        }

        public async Task<IActionResult> MyTickets()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var models = await ticketService.GetMyTicketsAsync(userId);

            return View(models);
        }
    }
}
