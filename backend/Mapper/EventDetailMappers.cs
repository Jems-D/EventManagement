using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DTO;
using backend.Features.Events.CreateEvents;

namespace backend.Mapper
{
    public static class EventDetailMappers
    {
        public static AddEventDetailsCommand ToAddEventDetailsCommand(
            this AddEventDetailsDTO dto,
            int id
        )
        {
            return new AddEventDetailsCommand(
                id,
                dto.EventTimeStart,
                dto.EventTimeEnd,
                dto.Venue,
                dto.VenueAddress,
                dto.VenueCapacity,
                dto.Status,
                dto.Purpose,
                dto.Description
            );
        }
    }
}
