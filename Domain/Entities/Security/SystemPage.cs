using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual SystemModule Module { get; set; }

        public virtual IEnumerable<SystemPageAction> Actions { get; set; }
    }
}
