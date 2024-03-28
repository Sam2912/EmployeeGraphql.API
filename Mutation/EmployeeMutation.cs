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
            .Argument<NonNullGraphType<EmployeeInput>>("create")
            .Resolve(resolve: context =>
            {
                var input = context.GetArgument<EmployeeInput>("create");
                 IEmployee employee = null;
                if(input.FullTimeEmployeeInput is not null){
                    employee = new FullTimeEmployee()
                    {
                        Id = input.FullTimeEmployeeInput.Id,
                        Name = input.FullTimeEmployeeInput.Name,
                        Status = input.FullTimeEmployeeInput.Status,
                        Department = input.FullTimeEmployeeInput.Department,
                        Salary = input.FullTimeEmployeeInput.Salary
                    };
                }
                else if (input.PartTimeEmployeeInput is not null)
                {
                    employee = new PartTimeEmployee()
                    {
                        Id = input.PartTimeEmployeeInput.Id,
                        Name = input.PartTimeEmployeeInput.Name,
                        Status = input.PartTimeEmployeeInput.Status,
                        Department = input.PartTimeEmployeeInput.Department,
                        HourlyRate = input.PartTimeEmployeeInput.HourlyRate
                    };
                }

                IEmployee employee1 = employeeService.AddEmployee(employee);

                return employee1;
                return null;
            });

            Field<IEmployeeType>("updateEmployee")
                .Argument<NonNullGraphType<EmployeeUpdateInput>>("input")
                .Resolve(resolve: context =>
                {
                    var input = context.GetArgument<EmployeeUpdateDto>("input");
                    IEmployee employee = null;
                    if (input.Type == EmployeeTypeEnum.FullTime)
                    {
                        employee = new FullTimeEmployee()
                        {
                            Id = input.Id,
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
                            Id = input.Id,
                            Name = input.Name,
                            Status = input.Status,
                            Department = input.Department,
                            HourlyRate = input.HourlyRate ?? 0
                        };
                    }

                    IEmployee employee1 = employeeService.UpdateEmployee(employee);

                    return employee1;

                });

            Field<IEmployeeType>("deleteEmployee")
                      .Argument<NonNullGraphType<IntGraphType>>("employeeId")
                      .Resolve(resolve: context =>
                      {
                          var employeeId = context.GetArgument<int>("employeeId");
                          IEmployee employee1 = employeeService.DeleteEmployee(employeeId);
                          return employee1;
                      });

        }
    }
}