using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Class;
using backend.DBContext;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly EventDbContext _context;

        public EventController(EventDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<EventItems>> PostEvents(EventItems eT)
        {
            _context.EventManagement.Add(eT);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEventItem), new { id = eT.Id }, eT);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventItems>> GetEventItem(int id)
        {
            var item = await _context.EventManagement.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
