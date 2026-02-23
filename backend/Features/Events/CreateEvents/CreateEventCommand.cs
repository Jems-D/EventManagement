using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace backend.Features.Events.CreateEvents
{
    public record CreateEventCommand(string EventName) : IRequest<string>;
}
