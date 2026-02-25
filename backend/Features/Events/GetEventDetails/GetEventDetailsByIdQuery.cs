using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DTO;
using MediatR;

namespace backend.Features.Events.GetEventDetails
{
    public record GetEventDetailsByIdQuery(int Id) : IRequest<EventBooking?>;

    public record GetEventDetailsQuery : IRequest<List<EventBooking>?>;
}
