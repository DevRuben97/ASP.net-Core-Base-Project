using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs.Security.Permissions
{
    public class UserModulePageActionDto
    {
        public int ActionId { get; set; }

        public string ActionName { get; set; }

        public string ActionUrl { get; set; }

        public bool Active { get; set; }
    }
}
