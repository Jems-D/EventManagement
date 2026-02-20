using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DTO;

namespace backend.Mappers.EventBookingMappers
{
    public static class EventBookingMappers
    {
        public static EventBookingDTO ToEventBooking(this EventBooking ev)
        {
            return new EventBookingDTO { EventName = ev.EventName };
        }

        public static EventBooking ToEventBookingFromDTO(this CreateEventBookingDTO dto)
        {
            return new EventBooking { EventName = dto.EventName };
        }
    }
}
