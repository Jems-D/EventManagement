using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.Features.Events.GetEvent;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Events.GetEventDetails
{
    public class GetEventDetailsByIdQueryHandler
        : IRequestHandler<GetEventDetailsByIdQuery, EventBooking?>
    {
        private readonly EventDbContext _context;

        public GetEventDetailsByIdQueryHandler(EventDbContext context)
        {
            _context = context;
        }

        public async Task<EventBooking?> Handle(
            GetEventDetailsByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var eventBooked = await _context
                .EventManagement.Include(e => e.EventDetails)
                .FirstOrDefaultAsync(e => e.EventId == request.Id);
            if (eventBooked is null)
            {
                return null;
            }
            return eventBooked;
        }
    }
}
