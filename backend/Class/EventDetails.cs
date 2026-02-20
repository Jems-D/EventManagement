using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    [Table("EventDetails")]
    public class EventDetails
    {
        [Key]
        [Column("Event_Details_ID", TypeName = "int")]
        public int EventDetailsId { get; set; }
        public int EventId { get; set; }

        public int RequesterId { get; set; }

        [Column("Event_Time_Start", TypeName = "datetime")]
        public DateTime EventTimeStart { get; set; }

        [Column("Event_Time_End", TypeName = "datetime")]
        public DateTime EventTimeEnd { get; set; }

        [Column("Venue", TypeName = "varchar(250)")]
        public string? Venue { get; set; }

        [Column("Venue_Address", TypeName = "varchar(250)")]
        public string? VenueAddress { get; set; }

        [Column("VenueCapacity", TypeName = "int")]
        public int VenueCapacity { get; set; }

        [Column("Status", TypeName = "varchar(50)")]
        public string? Status { get; set; }

        [Column("Purpose", TypeName = "varchar(100)")]
        public string? Purpose { get; set; }

        [Column("Description", TypeName = "text")]
        public string? Description { get; set; }

        [ForeignKey("EventId")]
        public EventBooking EventBooking { get; set; }

        [ForeignKey("RequesterId")]
        public UserAccount UserAccount { get; set; }
    }
}
