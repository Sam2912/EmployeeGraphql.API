using EmployeeGraphql.API.Resolver;
using EmployeeGraphql.API.Types;
using GraphQL.Types;

namespace EmployeeGraphql.API.Mutation
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(IEmployeeResolver employeeResolver)
        {
            Field<IEmployeeType>("addEmployee")
            .Argument<NonNullGraphType<EmployeeInput>>("create")
            .ResolveAsync(resolve: async context => await employeeResolver.CreateEmployeeAsync(context));

            Field<IEmployeeType>("updateEmployee")
                .Argument<NonNullGraphType<EmployeeUpdateInput>>("update")
                .ResolveAsync(async context => await employeeResolver.UpdateEmployee(context));

            Field<IEmployeeType>("deleteEmployee")
                      .Argument<NonNullGraphType<EmployeeDeleteInput>>("delete")
                      .ResolveAsync(async context => await employeeResolver.DeleteEmployee(context));

        }
    }
}