using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Security
{
   public class SystemModule
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }



        public virtual IEnumerable<RolePermission> RolePermissions { get; set; }

        public virtual IEnumerable<SystemPage> SystemPages { get; set; }
    }
}
