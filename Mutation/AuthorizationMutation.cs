using System.Security.Authentication;
using EmployeeGraphql.API.Authorization;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types.Authorization;
using GraphQL;
using GraphQL.Types;

namespace EmployeeGraphql.API.Mutation
{
    public class AuthorizationMutation : ObjectGraphType
    {
        private readonly IAuthService _authService;

        public AuthorizationMutation(IAuthService authService)
        {
            _authService = authService;
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
           });

            Field<ApplicationUserType>(
                       "createUser").Argument<CreateUserInput>("input")
                       .ResolveAsync(resolve: async context =>
                       {
                           var input = context.GetArgument<CreateUserInput>("input");
                           // Your user creation logic here
                           ApplicationUser applicationUser = await _authService.CreateUser(new CreateUserDto
                           {
                               UserName = input.UserName,
                               Email = input.Email,
                               Password = input.Password
                           });

                           return applicationUser;
                       });
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