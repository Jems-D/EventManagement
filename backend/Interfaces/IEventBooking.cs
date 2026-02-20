using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DTO;

namespace backend.Interfaces
{
    public interface IEventBooking
    {
        Task<EventBookingDTO> CreateEvent(EventBooking eventBooking);
    }
}
