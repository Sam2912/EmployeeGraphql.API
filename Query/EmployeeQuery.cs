using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphql.API
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            Field<EmployeeUnion>("employee")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .Resolve(resolve: context =>
                 {
                     var id = context.GetArgument<Guid>("id");
                     return employeeService.GetEmployeeById(id);
                 });


            Field<ListGraphType<EmployeeUnion>>("filteredEmployee")
                       .Argument<DepartmentEnumType>("dept")
                       .Argument<StatusEnumType>("status")
                       .Resolve(resolve: context =>
                            {
                                var dept = context.GetArgument<Department>("dept");
                                var status = context.GetArgument<Status>("status");

                                return employeeService.GetEmployeeByDeptStatus(dept, status);
                            });

            Field<ListGraphType<EmployeeUnion>>("employees")
            .Resolve(context =>
            {
                return employeeService.GetEmployees();
            }).Authorize();

            Field<ListGraphType<IEmployeeType>>("employeesWithInterface")
           .Resolve(context =>
            {
                return employeeService.GetEmployees();
            });
        }
    }

}

