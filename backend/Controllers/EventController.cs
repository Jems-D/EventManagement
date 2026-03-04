using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using backend.Features.Events.CreateEvents;
using backend.Features.Events.GetEvent;
using backend.Features.Events.GetEventDetails;
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

        [HttpPost("api/eventdetails")]
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

        [HttpGet("details")]
        public async Task<ActionResult<EventBooking>> GetEventDetailsById([FromQuery] int id)
        {
            var eventDetails = await _sender.Send(new GetEventDetailsByIdQuery(id));
            if (eventDetails is null)
                return NotFound("No event found");
            return Ok(eventDetails);
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

        [HttpGet("eventdetails")]
        public async Task<ActionResult<List<EventBookingDTO>>> GetAllEventDetails()
        {
            var allEventDetails = await _sender.Send(new GetEventDetailsQuery());
            if (allEventDetails is null)
                return NotFound("No events found");

            return allEventDetails.Select(s => s.ToEventBookingDTO()).ToList();
        }
    }
}
