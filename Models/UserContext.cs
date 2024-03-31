using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Models
{
    public class MyUserContext : Dictionary<string, object?>
    {
        public ClaimsPrincipal User { get; }

        public MyUserContext(HttpContext context)
        {
            User = context.User;
        }
    }
}