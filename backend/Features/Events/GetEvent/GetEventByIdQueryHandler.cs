using System;
using Azure.Core;
using backend.Class;
using backend.DBContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace backend.Features.Events.GetEvent;

public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, EventBooking?>
{
    private readonly EventDbContext _context;

    public GetEventByIdQueryHandler(EventDbContext context)
    {
        _context = context;
    }

    public async Task<EventBooking?> Handle(
        GetEventByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        var eventBooked = await _context.EventManagement.FindAsync(request.id);
        if (eventBooked is null)
        {
            return null;
        }
        return eventBooked;
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
