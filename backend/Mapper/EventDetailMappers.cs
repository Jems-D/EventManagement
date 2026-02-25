using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
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

        public static EventBookingDTO ToEventBookingDTO(this EventBooking eventBookings)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            return new EventBookingDTO
            {
                EventName = eventBookings.EventName,
                eventDetails =
                    eventBookings.EventDetails == null
                        ? null
                        : new List<EventDetailsDTO>
                        {
                            new EventDetailsDTO
                            {
                                EventDetailsId = eventBookings.EventDetails.EventDetailsId,
                                EventTimeStart = eventBookings.EventDetails.EventTimeStart,
                                EventTimeEnd = eventBookings.EventDetails.EventTimeEnd,
                                Venue = eventBookings.EventDetails.Venue,
                                VenueAddress = eventBookings.EventDetails.VenueAddress,
                                VenueCapacity = eventBookings.EventDetails.VenueCapacity,
                                Status = eventBookings.EventDetails.Status,
                                Purpose = eventBookings.EventDetails.Purpose,
                                Description = eventBookings.EventDetails.Description,
                            },
                        },
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
}
