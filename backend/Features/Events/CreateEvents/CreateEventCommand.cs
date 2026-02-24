using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend.Features.Events.CreateEvents
{
    public record CreateEventCommand(string EventName) : IRequest<string>;

    public record AddEventDetailsCommand(
        int EventID,
        DateTime EventTimeStart,
        DateTime EventTimeEnd,
        string Venue,
        string VenueAddress,
        int VenueCapacity,
        string Status,
        string Purpose,
        string Description
    ) : IRequest<int>;
}
