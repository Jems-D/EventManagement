using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Events.GetEventDetails
{
    public class GetEventDetailsQueryHandler
        : IRequestHandler<GetEventDetailsQuery, List<EventBooking>?>
    {
        private readonly EventDbContext _context;

        public GetEventDetailsQueryHandler(EventDbContext context)
        {
            _context = context;
        }

        public async Task<List<EventBooking>?> Handle(
            GetEventDetailsQuery request,
            CancellationToken cancellationToken
        )
        {
            var allEventDetails = await _context
                .EventManagement.Include(e => e.EventDetails)
                .ToListAsync();

            if (allEventDetails is null)
                return null;

            return allEventDetails;
        }
    }
}
