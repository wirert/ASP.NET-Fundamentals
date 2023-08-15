namespace Homies.Controllers
{
    using Homies.Data;
    using Homies.Data.Entities;
    using Homies.Models.Event;
    using Homies.Models.Type;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;

    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;

        public EventController(HomiesDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> All()
        {
            var model = await context.Events
                .AsNoTracking()
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Organiser = e.Organiser.UserName,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name
                })
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            var types = await GetTypesAsync();

            var model = new EventFormViewModel()
            {
                Types = types
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            var types = await GetTypesAsync();

            if (types.All(t => t.Id != model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Invalid type");
            }

            if (model.End < model.Start)
            {
                ModelState.AddModelError(nameof(model.End), "End date can't be before start date");
            }

            if (!ModelState.IsValid)
            {
                model.Types = types;

                return View(model);
            }

            var newEvent = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                End = model.End,
                Start = model.Start,
                OrganiserId = UserId(),
                TypeId = model.TypeId
            };

            context.Add(newEvent);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await context.Events.FindAsync(id);

            if (eventToEdit == null || this.UserId() != eventToEdit.OrganiserId)
            {
                return BadRequest();
            }

            var model = new EventFormViewModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                End = eventToEdit.End,
                Start = eventToEdit.Start,
                Types = await GetTypesAsync()
            };

            TempData["EventId"] = id;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model)
        {
            var types = await GetTypesAsync();

            if (types.All(t => t.Id != model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Invalid type");
            }

            if (model.End < model.Start)
            {
                ModelState.AddModelError(nameof(model.End), "End date can't be before start date");
            }

            if (!ModelState.IsValid)
            {
                model.Types = types;

                return View(model);
            }

            var eventId = TempData["EventId"];

            if (eventId == null)
            {
                return BadRequest();
            }

            var eventToEdit = await context.Events.FindAsync((int)eventId);

            eventToEdit!.Start = model.Start;
            eventToEdit.End = model.End;
            eventToEdit.Description = model.Description;
            eventToEdit.Name = model.Name;
            eventToEdit.TypeId = model.TypeId;

            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var eventToJoin = await context.Events.FindAsync(id);

            if (eventToJoin == null)
            {
                return NotFound();
            }

            if (eventToJoin.OrganiserId == this.UserId())
            {
                return BadRequest();
            }

            bool isAlreadyParticipant = await context
                                            .EventsParticipants
                                            .AnyAsync(ep => ep.HelperId == UserId() &&
                                                            ep.EventId == eventToJoin.Id);
            if (isAlreadyParticipant)
            {
                return RedirectToAction("All");
            }

            var eventPart = new EventParticipant()
            {
                Event = eventToJoin,
                HelperId = this.UserId()
            };

            await context.AddAsync(eventPart);
            await context.SaveChangesAsync();

            return RedirectToAction("Joined");
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var model  = await context.EventsParticipants
                .Where(ep => ep.HelperId == UserId())
                .Select(ep => new AllEventViewModel()
                {
                    Name = ep.Event.Name,
                    Id = ep.Event.Id,
                    Organiser = ep.Event.Organiser.UserName,
                    Start = ep.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = ep.Event.Type.Name                    
                })
                .ToListAsync();

            return View(model ?? new List<AllEventViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var eventToLeave = await context.EventsParticipants
                .Where(ep => ep.HelperId == UserId() && ep.Event.Id == id)
                .FirstOrDefaultAsync();

            if (eventToLeave == null)
            {
                return NotFound();
            }

            context.Remove(eventToLeave);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventDetailsViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    End = e.End.ToString("yyyy-MM-dd H:mm"),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }


        private async Task<IEnumerable<TypeViewModel>> GetTypesAsync()
        {
            var types = await context.Types
                .AsNoTracking()
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();

            return types ?? new List<TypeViewModel>();
        }

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
