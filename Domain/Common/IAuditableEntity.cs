using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
   public interface IAuditableEntity
    {
        /// <summary>
        /// Fecha de creacion del registro
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Fecha de Modificacón del registro.
        /// </summary>
        public DateTime ModifierDate { get; set; }

        /// <summary>
        ///  User Creation Id
        /// </summary>

        public int UserCreationId { get; set; }

        /// <summary>
        /// Modifier User Id
        /// </summary>
        public int ModifierUserId { get; set; }

        /// <summary>
        /// Estado del registro.
        /// </summary>
        public string Status { get; set; }
    }
}
