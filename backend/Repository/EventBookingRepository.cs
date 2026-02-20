using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using backend.DTO;
using backend.Interfaces;
using backend.Mappers.EventBookingMappers;

namespace backend.Repository
{
    public class EventBookingRepository : IEventBooking
    {
        private readonly EventDbContext _context;

        public EventBookingRepository(EventDbContext context)
        {
            _context = context;
        }

        public async Task<EventBookingDTO> CreateEvent(EventBooking eventBooking)
        {
            var createEvent = await _context.AddAsync(eventBooking);
            await _context.SaveChangesAsync();
            return eventBooking.ToEventBooking();
        }
    }
}
