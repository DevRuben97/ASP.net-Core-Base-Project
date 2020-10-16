using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entity
{
    public class CurrentUser
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }
    }
}
