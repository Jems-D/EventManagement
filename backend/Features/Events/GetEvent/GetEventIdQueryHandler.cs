using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using backend.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Events.GetEvent
{
    public class GetEventIdQueryHandler : IRequestHandler<GetEventIdQuery, int?>
    {
        private readonly EventDbContext _context;

        public GetEventIdQueryHandler(EventDbContext context)
        {
            _context = context;
        }

        public async Task<int?> Handle(GetEventIdQuery request, CancellationToken cancellationToken)
        {
            int? eventId = await _context
                .EventManagement.Where(e => e.EventId == request.id)
                .Select(e => e.EventId)
                .FirstOrDefaultAsync();
            if (eventId is null)
            {
                return null;
            }
            return eventId;
        }
    }
}
