using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public static class ApiRoutes
    {
        public const  string CONTROLLER = "api/[controller]";

        public const string Action = "[action]";


        public const string FindOneMethod = "[action]/{Id}";

        public const string FindOne = "{Id}";
    }
}
