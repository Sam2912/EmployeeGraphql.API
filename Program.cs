using System.Text;
using EmployeeGraphql.API;
using EmployeeGraphql.API.Authorization;
using EmployeeGraphql.API.DbContext;
using EmployeeGraphql.API.Mapping;
using EmployeeGraphql.API.Mutation;
using EmployeeGraphql.API.Resolver;
using EmployeeGraphql.API.Schema;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Validations;
using FluentValidation;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using EmployeeGraphql.API.Models;
using System.Security.Claims;
using EmployeeGraphql.API.Constants;
using EmployeeGraphql.API.Repositories;
using EmployeeGraphql.API.Backgroundservices;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configure identity options as needed
    options.SignIn.RequireConfirmedAccount = false;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = configuration["Jwt:Issuer"],
        ValidAudience = configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(EmployeeConstant.ADMIN_POLICY, policy => policy.RequireClaim(ClaimTypes.Role, EmployeeConstant.ROLE_ADMIN));
    // Add more policies as needed
});


builder.Services.AddScoped<IAuthService, AuthService>();

// Add services to the container.
builder.Services.AddScoped<IEmployeeResolver, EmployeeResolver>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<EmployeeMutation>();
builder.Services.AddScoped<AuthorizationMutation>();
builder.Services.AddScoped<ISchema, EmployeeSchema>();
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Add AutoMapper
builder.Services.AddValidatorsFromAssemblyContaining<EmployeeInputValidator>(ServiceLifetime.Singleton);
builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowSpecificOrigin",
           builder =>
           {
               builder.WithOrigins("http://localhost:5173") // Replace with your allowed origin
                   .AllowAnyHeader()
                   .AllowAnyMethod();
           });
   });
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<MyUserContext>(provider =>
{
    var httpContextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    var httpContext = httpContextAccessor.HttpContext;
    // You may need to adjust this logic based on how you set up MyUserContext
    return new MyUserContext(httpContext);
});

builder.Services.AddGraphQL(b =>
{
    b
    //.AddAutoSchema<EmployeeQuery>()  // schema
    .AddGraphTypes()
    // serializer
    .AddSystemTextJson()
    //.AddUserContextBuilder(httpContext => new MyUserContext(httpContext))
    .AddAuthorizationRule();
});

builder.Services.AddControllers();

// Add the background service
//builder.Services.AddHostedService<UserManagementBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // Use GraphQL Playground
    // url to host GraphQL endpoint
    app.UseGraphQLPlayground(
        "/",                               // url to host Playground at
        new GraphQL.Server.Ui.Playground.PlaygroundOptions
        {
            GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
            SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
        });

    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>("/graphql");



app.Run();