using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Security
{
    /// <summary>
    /// The actions of a page.
    /// </summary>
   public class PermissonPageAction
    {
        public int Id { get; set; }
        [ForeignKey("PermisionPage")]
        public int PermisionPageId { get; set; }

        [ForeignKey("Action")]
        public int ActionId { get; set; }

        /// <summary>
        /// Destription of the action
        /// </summary>
        /// 

        public virtual SystemPageAction Action { get; set; }

        //Navigation properties:
        public virtual PermisionPage PermisionPage { get; set; }
    }
}
