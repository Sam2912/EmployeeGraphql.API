using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Authorization
{
    using EmployeeGraphql.API.Models;
    using GraphQL.Types;

    public class AuthPayload : ObjectGraphType<AuthPayloadDto>
    {
        public AuthPayload()
        {
            Name = "AuthPayload";

            Field<StringGraphType>("token", resolve: context => context.Source.Token);
            Field<BooleanGraphType>("success", resolve: context => context.Source.Success);
            Field<ListGraphType<StringGraphType>>("errors", resolve: context => context.Source.Errors);
        }

        public string Token { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
    }

}