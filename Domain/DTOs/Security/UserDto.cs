using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Security
{
  public  class UserDto
    {
        public string Nombre { get; set; }


        public string Apellido { get; set; }

        public string Cedula { get; set; }

        public string Password { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string Estado { get; set; }
    }
}
