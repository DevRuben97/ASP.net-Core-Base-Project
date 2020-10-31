using System.Collections.Generic;

namespace Domain.Entities.Security
{
    public class RolePermission
    {
        public int Id { get; set; }

        public int RolId { get; set; }

        public int ModuleId { get; set; }



        //Navigation Properties:

        public virtual SystemModule Module { get; set; }

        public virtual Role Role { get; set; }

        public virtual IEnumerable<PermisionPage> Pages { get; set; }
    }
}
