using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.DbContext;
using GraphQL.Types;

namespace EmployeeGraphql.API.Types.Authorization
{
    public class ApplicationUserType : ObjectGraphType<ApplicationUser>
    {
        public ApplicationUserType()
        {
            Field(x => x.UserName);
            Field(x => x.EmailConfirmed);
        }
    }
}