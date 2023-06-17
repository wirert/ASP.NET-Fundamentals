using Homies.Data;
using Homies.Data.Entities;
using Homies.Models.Event;
using Homies.Services.Contracts;
using Microsoft.EntityFrameworkCore;

using Event =  Homies.Data.Entities.Event;

using static Homies.Constants.DataConstants.Event;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        public readonly HomiesDbContext context;

        public EventService(HomiesDbContext _context)
        {
            context = _context;
        }

        public async Task AddEventAsync(string userId, AddEventViewModel model)
        {
           await context.Events.AddAsync(new Event()
            {
               Description = model.Description,
               CreatedOn = model.CreatedOn,
               End = model.End,
               Start = model.Start,
               Name = model.Name,
               TypeId = model.TypeId,
               OrganiserId = userId               
            });

            await context.SaveChangesAsync();
        }

        public async Task EditEventAsync(AddEventViewModel model)
        {
            var entity = await context.Events.SingleOrDefaultAsync(e => e.Id == model.Id);

            if (entity == null)
            {
                return;
            }

            entity.Start = model.Start;
            entity.End = model.End;
            entity.Name = model.Name;
            entity.TypeId = model.TypeId;
            entity.Description = model.Description;

            await context.SaveChangesAsync();
        }

        public async Task<AddEventViewModel?> FindEventByIdAsync(int id)
        {
            return await context.Events
                .Where(e => e.Id == id)
                .Select(e => new AddEventViewModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    CreatedOn = e.CreatedOn,
                    End = e.End,
                    Start = e.Start,
                    TypeId = e.TypeId ,
                    Id = id
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetAllEventsAsync()
        {
            return await context.Events
                .Select(e => new AllEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllEventViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await context.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(ep => new AllEventViewModel()
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(DateTimeFormat),
                    Type = ep.Event.Type.Name,
                    Organiser = ep.Event.Organiser.UserName
                })
                .ToListAsync();
        }

        public async Task<ICollection<TypeViewModel>> GetTypesAsync()
        {
            return await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name= t.Name,
                })
                .ToListAsync();
        }

        public async Task JoinAsync(string userId, int eventId)
        {
            var user = await context.Users.FindAsync(userId);

            var userEvent = new EventParticipant()
            {
                EventId = eventId,
                HelperId = userId,
                Helper = user
            };

            await context.EventsParticipants.AddAsync(userEvent);
            await context.SaveChangesAsync();   
        }
    }
}
