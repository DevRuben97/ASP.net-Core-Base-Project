using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Security
{
    public class Role : IdentityRole<int>, IAuditableEntity, IEntity
    {

        public DateTime CreationDate { get; set; }
        public DateTime ModifierDate { get; set; }
        public int UserCreationId { get; set; }
        public int ModifierUserId { get; set; }
        public string Status { get; set; }
        //Propiedades de Navegacion:

        public IEnumerable<UserRoles> UserRoles { get; set; }
    }
}
