using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
   public interface IEntity
    {
        /// <summary>
        /// Identificador de la tabla.
        /// </summary>
        public int Id { get; set; }
    }
}
