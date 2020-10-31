using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.System
{
    /// <summary>
    /// System Status
    /// </summary>
   public class SystemEntityStatus
    {
        public int Id { get; set; }

        /// <summary>
        /// Description of the status:
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Type of the status: General or Single
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The entity Name of the status, NULL  if is Type General.
        /// </summary>

        public string EntityName { get; set; }
    }
}
