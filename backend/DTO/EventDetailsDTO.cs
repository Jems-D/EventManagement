using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTO
{
    public class EventDetailsDTO
    {
        public int EventDetailsId { get; set; }
        public DateTime EventTimeStart { get; set; }
        public DateTime EventTimeEnd { get; set; }
        public string Venue { get; set; }
        public string VenueAddress { get; set; }
        public int VenueCapacity { get; set; }
        public string Status { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
    }
}
