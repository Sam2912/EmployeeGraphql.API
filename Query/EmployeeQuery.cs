using System.Linq.Expressions;
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
            
            this.Authorize();

            Field<EmployeeUnion>("employee")
            .Argument<NonNullGraphType<GuidGraphType>>("id")
            .ResolveAsync(resolve: async context =>
                 {
                     var id = context.GetArgument<Guid>("id");
                     return await employeeService.GetEmployeeByIdAsync(id);
                 });


            Field<ListGraphType<EmployeeUnion>>("filteredEmployee")
                       .Argument<DepartmentEnumType>("dept")
                       .Argument<StatusEnumType>("status")
                       .ResolveAsync(async context =>
                            {
                                var dept = context.GetArgument<Department>("dept");
                                var status = context.GetArgument<Status>("status");

                                Expression<Func<Employee, bool>> predicate = emp => emp.Department == dept && emp.Status == status;
                                return await employeeService.GetAsync(predicate);
                            });

            Field<ListGraphType<EmployeeUnion>>("employees")
            .ResolveAsync(async context => await employeeService.GetAllEmployeesAsync())
            .AuthorizeWithPolicy(EmployeeConstant.ADMIN_POLICY);

            Field<ListGraphType<IEmployeeType>>("employeesWithInterface")
           .ResolveAsync(async context => await employeeService.GetAllEmployeesAsync());

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



