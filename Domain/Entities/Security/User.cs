using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities.Security
{
    public class User : IdentityUser<int>, IAuditableEntity, IEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string SurName { get; set; }
        [Required]
        public string Identification { get; set; }


        public DateTime CreationDate { get;set; }
        public DateTime ModifierDate { get;set; }
        public int UserCreationId { get;set; }
        public int ModifierUserId { get;set; }
        public string Status { get;set; }

        //Propiedades de navegacion:

        public IEnumerable<UserRoles> UserRoles { get; set; }
    }
}
