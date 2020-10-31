using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities.Security
{
    public class SystemPage
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }

        [Required]

        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Path { get; set; }

        public int Order { get; set; }
        [ForeignKey("Parent")]
        public int? ParentId { get; set; }

        public IEnumerable<SystemPage> Childs { get; set; }

        public SystemPage Parent { get; set; }

        public virtual SystemModule Module { get; set; }

        public virtual IEnumerable<SystemPageAction> Actions { get; set; }
    }
}
