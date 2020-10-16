using Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Security
{
   public class UserRoles: IdentityUserRole<int>, IAuditableEntity
    {

        public DateTime CreationDate {get;set; }
        public DateTime ModifierDate {get;set; }
        public int UserCreationId {get;set; }
        public int ModifierUserId {get;set; }
        public string Status {get;set; }

        public Role Rol { get; set; }

        public User User { get; set; }
    }
}
