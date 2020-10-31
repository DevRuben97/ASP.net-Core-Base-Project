using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Security.Permissions
{
   public class UserModulePagesDto
    {
        public string  ModulePage { get; set; }

        public string ModulePageUrl { get; set; }

        public int ModuleId { get; set; }

        public string ModuleName { get; set; }

        public int ModulePageId { get; set; }

        public IEnumerable<UserModulePageActionDto> Actions { get; set; }
    }
}
