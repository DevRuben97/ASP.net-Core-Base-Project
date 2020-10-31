using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Security.Permissions
{
   public class UserModulesDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public IEnumerable<UserModulePagesDto> Pages { get; set; }
    }
}
