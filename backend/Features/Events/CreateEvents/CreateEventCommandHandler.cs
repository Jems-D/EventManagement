using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using MediatR;

namespace backend.Features.Events.CreateEvents
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, string>
    {
        private readonly EventDbContext _context;

        public CreateEventCommandHandler(EventDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(
            CreateEventCommand request,
            CancellationToken cancellationToken
        )
        {
            var eventCreated = new EventBooking { EventName = request.EventName };
            _context.EventManagement.Add(eventCreated);
            await _context.SaveChangesAsync();

            return eventCreated.EventName;
        }
    }
}
