namespace EmployeeGraphql.API.Types.Authorization
{
    using GraphQL.Types;
    using Microsoft.AspNetCore.Identity;

    public class RoleType : ObjectGraphType<IdentityRole>
    {
        public RoleType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The ID of the role.");
            Field(x => x.Name, nullable: false).Description("The name of the role.");
        }
    }

}