using Microsoft.EntityFrameworkCore;

using BusStation.Data;
using BusStation.Data.Entities;
using BusStation.Models;
using BusStation.Services.Contracts;

namespace BusStation.Services
{
    public class TicketService : ITicketService
    {
        private readonly BusStationDbContext dbContext;

        public TicketService(BusStationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }        

        public async Task CreateAsync(CreateTicketsViewModel model)
        {
            var destination = await dbContext.Destinations.FindAsync(model.DestinationId);

            if (destination == null)
            {
                throw new ArgumentException("Invalid Destination Id");
            }

            for (int i = 0; i < model.TicketsCount; i++)
            {
                destination.Tickets.Add(new Ticket()
                {
                    Price = model.Price,
                    Destination = destination
                });
            }   
            
            await dbContext.SaveChangesAsync();
        }

        public async Task BookAsync(string userId, int destId)
        {
            var user = await dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid User Id!");
            }

            var ticket = await dbContext.Tickets
                .Where(t => t.DestinationId == destId && t.UserId == null)
                .FirstOrDefaultAsync();

            if (ticket == null) 
            {
                throw new ArgumentException($"There is no more tickets or Destination Id is wrong");
            }  

            ticket.User = user;

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MyTicketViewModel>> GetMyTicketsAsync(string userId)
        {
            return await dbContext.Tickets
                .Where(t => t.UserId == userId)
                .Select(t => new MyTicketViewModel() 
                {
                    Destination = $"From {t.Destination.Origin} to {t.Destination.DestinationName}",
                    DestinationImage = t.Destination.ImageUrl,
                    DateAndTime = $"Date: {t.Destination.Date}, Hour: {t.Destination.Time}",
                    TicketPrice = t.Price
                })
                .ToListAsync();
        }
    }
}
