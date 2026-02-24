using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using MediatR;

namespace backend.Features.Events.CreateEvents
{
    public class AddEventDetailsHandler : IRequestHandler<AddEventDetailsCommand, int>
    {
        private readonly EventDbContext _context;

        public AddEventDetailsHandler(EventDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(
            AddEventDetailsCommand request,
            CancellationToken cancellationToken
        )
        {
            var eventDetailsBooked = new EventDetails
            {
                EventId = request.EventID,
                EventTimeStart = request.EventTimeStart,
                EventTimeEnd = request.EventTimeEnd,
                Venue = request.Venue,
                VenueAddress = request.VenueAddress,
                VenueCapacity = request.VenueCapacity,
                Status = request.Status,
                Purpose = request.Purpose,
                Description = request.Description,
            };

            await _context.EventDetails.AddAsync(eventDetailsBooked);
            await _context.SaveChangesAsync();
            return eventDetailsBooked.EventId;
        }
    }
}
