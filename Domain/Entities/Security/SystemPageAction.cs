using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Security
{
   public class SystemPageAction
    {

        public int Id { get; set; }

        [ForeignKey("Page")]
        public int PageId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual SystemPage Page { get; set; }
    }
}
