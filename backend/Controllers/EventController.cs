using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using backend.Interfaces;
using backend.Mappers.EventBookingMappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IEventBooking _repoEvent;

        public EventController(IEventBooking repoEvent)
        {
            _repoEvent = repoEvent;
        }

        [HttpPost]
        public async Task<ActionResult<EventBooking>> PostEvents(
            [FromBody] CreateEventBookingDTO eventBookingDTO
        )
        {
            var createdEvent = eventBookingDTO.ToEventBookingFromDTO();
            await _repoEvent.CreateEvent(createdEvent);

            return Ok(createdEvent);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventBooking>> GetEventItem(int id)
        {
            return Ok();
        }
    }
}
