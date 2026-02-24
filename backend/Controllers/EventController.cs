using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using backend.Features.Events.CreateEvents;
using backend.Features.Events.GetEvent;
using backend.Mapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ISender _sender;

        public EventController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("api/CreateEvent")]
        public async Task<ActionResult<string>> CreateEvent(CreateEventCommand eventCommand)
        {
            var createdEvent = await _sender.Send(eventCommand);
            return Ok(createdEvent);
        }

        [HttpPost("api/AddEventDetails")]
        public async Task<ActionResult<int>> AddEventDetails(
            [FromBody] AddEventDetailsDTO dto,
            [FromQuery] int id
        )
        {
            var eventId = await _sender.Send(new GetEventIdQuery(id));
            if (eventId is null)
                return NotFound("Event not found");

            var eventDetailsCommand = dto.ToAddEventDetailsCommand(id);
            var eventDetailsBooked = await _sender.Send(eventDetailsCommand);
            return Ok(eventDetailsBooked);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventBooking>> GetEventById(int id)
        {
            var eventBooked = await _sender.Send(new GetEventByIdQuery(id));
            if (eventBooked is null)
            {
                return NotFound();
            }
            return eventBooked;
        }
    }
}
