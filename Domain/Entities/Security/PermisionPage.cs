using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Security
{
    /// <summary>
    /// the pages of a module.
    /// </summary>
   public class PermisionPage
    {
        public int Id { get; set; }

        public int PermisionId { get; set; }
        [ForeignKey("Page")]
        public int PageId { get; set; }

        //Navigation properties:
        public SystemPage Page { get; set; }

        public RolePermission Permissions { get; set; }

        public IEnumerable<PermissonPageAction> Actions { get; set; }
    }
}
