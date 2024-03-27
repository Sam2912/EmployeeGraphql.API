using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphql.API.Mutation
{
    public class EmployeeMutation : ObjectGraphType
    {
        public EmployeeMutation(IEmployeeService employeeService)
        {
            Field<IEmployeeType>("addEmployee")
            .Argument<NonNullGraphType<EmployeeInput>>("input")
            .Resolve(resolve: context =>
            {
                var input = context.GetArgument<EmployeeInputDto>("input");
                IEmployee employee = null;
                if (input.Type == EmployeeTypeEnum.FullTime)
                {
                    employee = new FullTimeEmployee()
                    {
                        Id=input.Id,
                        Name = input.Name,
                        Status = input.Status,
                        Department = input.Department,
                        Salary = input.Salary ?? 0
                    };
                }
                else if (input.Type == EmployeeTypeEnum.PartTime)
                {
                    employee = new PartTimeEmployee()
                    {
                        Id=input.Id,
                        Name = input.Name,
                        Status = input.Status,
                        Department = input.Department,
                        HourlyRate = input.Salary ?? 0
                    };
                }

                IEmployee employee1 = employeeService.AddEmployee(employee);

                return employee1;
            
        });
        }
}
}