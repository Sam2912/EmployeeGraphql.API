using EmployeeGraphql.API.Authorization;
using EmployeeGraphql.API.Constants;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Types;
using EmployeeGraphql.API.Types.Authorization;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphql.API
{
    public class EmployeeQuery : ObjectGraphType
    {
        private readonly IAuthService _authService;

        public EmployeeQuery(IEmployeeService employeeService, IAuthService authService)
        {
            _authService = authService;

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
            }).AuthorizeWithPolicy(EmployeeConstant.ADMIN_POLICY);

            Field<ListGraphType<IEmployeeType>>("employeesWithInterface")
           .Resolve(context =>
            {
                return employeeService.GetEmployees();
            });

            Field<AuthPayload>("generateJwtToken")
            .Arguments(new QueryArguments(
            new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "username" },
            new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
            )).ResolveAsync(async context =>
            {
                var username = context.GetArgument<string>("username");
                var password = context.GetArgument<string>("password");

                // Your authentication logic here
                var token = await GenerateJwtToken(username, password);

                return token;
            }).AllowAnonymous();
        }

        public async Task<AuthPayloadDto> GenerateJwtToken(string username, string password)
        {
            var token = await _authService.GenerateJwtToken(username, password);
            if (token != null)
            {
                return new AuthPayloadDto
                {
                    Token = token,
                    Success = true,
                    Errors = (List<string>)null
                };
            }
            else
            {
                return new AuthPayloadDto
                {
                    Token = (string)null,
                    Success = false,
                    Errors = new List<string> { "Invalid username or password" }
                };
            }
            // // Return null or throw an exception for invalid credentials
            // throw new AuthenticationException("Invalid credentials");
        }
    }
}



