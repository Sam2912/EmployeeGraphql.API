using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Types.Input;

namespace EmployeeGraphql.API.Mutation
{
    public class EmployeeMutationType : ObjectType<IEmployeeMutationResolver>
    {

        protected override void Configure(IObjectTypeDescriptor<IEmployeeMutationResolver> descriptor)
        {
            descriptor.Name(OperationTypeNames.Mutation);

            descriptor.Field(f => f.CreateEmployeeAsync(default, default))
                .Name("addEmployee")
                .Type<IEmployeeType>()
                .Argument("create", a => a.Type<EmployeeInputType>());
        }

        public EmployeeMutationType()
        {

            // Field<IEmployeeType>("addEmployee")
            // .Argument<NonNullGraphType<EmployeeInput>>("create")
            // .ResolveAsync(resolve: async context => await employeeResolver.CreateEmployeeAsync(context))
            // .AuthorizeWithPolicy(EmployeeConstant.ADMIN_POLICY);

            // Field<IEmployeeType>("updateEmployee")
            //     .Argument<NonNullGraphType<EmployeeUpdateInput>>("update")
            //     .ResolveAsync(async context => await employeeResolver.UpdateEmployeeAsync(context))
            //     .AuthorizeWithPolicy(EmployeeConstant.ADMIN_POLICY);

            // Field<IEmployeeType>("deleteEmployee")
            //           .Argument<NonNullGraphType<EmployeeDeleteInput>>("delete")
            //           .ResolveAsync(async context => await employeeResolver.DeleteEmployeeAsync(context))
            //           .AuthorizeWithPolicy(EmployeeConstant.ADMIN_POLICY);

        }
    }
}