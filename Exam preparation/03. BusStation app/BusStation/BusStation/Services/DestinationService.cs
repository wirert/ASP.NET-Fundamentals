using BusStation.Data;
using BusStation.Data.Entities;
using BusStation.Models;
using BusStation.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BusStation.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly BusStationDbContext dbContext;

        public DestinationService(BusStationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task AddAsync(AddDestinationViewModel model)
        {
            var destination = new Destination()
            {
                DestinationName = model.DestinationName,
                Origin = model.Origin,
                Date = model.Date.ToString("d"),
                Time = model.Date.ToString("t"),
                ImageUrl = model.ImageUrl
            };

            await dbContext.Destinations.AddAsync(destination);

            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllDestinationsViewModel>> GetAllDestinationsAsync()
        {
            return await dbContext.Destinations
                .Select(d => new AllDestinationsViewModel()
                {
                    Id = d.Id,
                    DestinationName = d.DestinationName,
                    Origin = d.Origin,
                    Date = d.Date,
                    Time = d.Time,
                    ImageUrl = d.ImageUrl,
                    Tickets = d.Tickets.Count(t => t.UserId == null)
                })
                .ToListAsync();
        }
    }
}
