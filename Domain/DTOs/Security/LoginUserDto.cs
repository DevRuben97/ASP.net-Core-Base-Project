using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Domain.DTOs.Security
{
   public class LoginUserDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
