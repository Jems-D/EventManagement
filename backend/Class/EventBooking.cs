using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Common;

namespace backend.Class
{
    /// <summary>
    /// Represent an Item in the Event Class
    /// </summary>
    [Table("EventBooking")]
    public class EventBooking
    {
        ///<summary>
        ///
        /// </summary>
        [Key]
        [Column("Event_ID", TypeName = "int")]
        public int EventId { get; set; }

        ///<summary>
        ///
        /// </summary>
        [Column("Event_Created", TypeName = "datetime")]
        public DateTime EventCreated { get; set; } = DateTime.Now;

        [Column("Event_Name", TypeName = "varchar(100)")]
        public string? EventName { get; set; } = string.Empty;

        ///<summary>
        ///
        /// </summary>
        [Column("Event_Updated", TypeName = "datetime")]
        public DateTime Event_Updated { get; set; } = DateTime.Now;

        [Column("Created_By", TypeName = "int")]
        public int CreatedBy { get; set; }

        [Column("Last_Updated_By", TypeName = "int")]
        public int UpdatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public UserAccount UserAccount { get; set; }
    }
}
