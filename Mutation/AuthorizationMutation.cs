using System.Security.Authentication;
using EmployeeGraphql.API.Authorization;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types.Authorization;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Identity;

namespace EmployeeGraphql.API.Mutation
{
    public class AuthorizationMutation : ObjectGraphType
    {
        private readonly IAuthService _authService;

        public AuthorizationMutation(IAuthService authService)
        {
            _authService = authService;

            Field<RoleType>("createRole")
            .Argument<NonNullGraphType<StringGraphType>>("name")
            .ResolveAsync(async context =>
               {
                   var roleName = context.GetArgument<string>("name");

                   var result = await _authService.CreateRole(roleName);

                   if (result.Succeeded)
                   {
                       return new IdentityRole { Name = roleName }; // Return the newly created role
                   }
                   else
                   {
                       // Handle the case where role creation fails
                       context.Errors.Add(new ExecutionError("Failed to create role."));
                       return null;
                   }
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

            Field<BooleanGraphType>("assignRolesToUser")
           .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "userId" },
                new QueryArgument<NonNullGraphType<ListGraphType<StringGraphType>>> { Name = "roles" }))
            .ResolveAsync(async context =>
               {
                   var userId = context.GetArgument<string>("userId");
                   var roles = context.GetArgument<List<string>>("roles");

                   var result = await _authService.AssignRolesToUser(userId, roles);

                   return result.Succeeded;
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