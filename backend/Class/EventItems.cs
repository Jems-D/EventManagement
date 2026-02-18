using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Class
{
    /// <summary>
    /// Represent an Item in the Event Class
    /// </summary>
    public class EventItems
    {
        ///<summary>
        ///
        /// </summary>
        public long Id { get; set; }

        ///<summary>
        ///
        /// </summary>
        public string? Name { get; set; }

        ///<summary>
        ///
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
