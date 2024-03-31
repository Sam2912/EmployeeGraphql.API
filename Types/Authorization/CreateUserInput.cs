using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Authorization
{
    using GraphQL.Types;

    public class CreateUserInput : InputObjectGraphType
    {
        public CreateUserInput()
        {
            Name = "CreateUserInput";
            Field<NonNullGraphType<StringGraphType>>("userName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
            // Add other fields as needed
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}