using EmployeeGraphql.API;
using EmployeeGraphql.API.Mapping;
using EmployeeGraphql.API.Mutation;
using EmployeeGraphql.API.Resolver;
using EmployeeGraphql.API.Schema;
using EmployeeGraphql.API.Services;
using EmployeeGraphql.API.Validations;
using FluentValidation;
using GraphQL;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IEmployeeResolver, EmployeeResolver>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<EmployeeMutation>();
builder.Services.AddSingleton<ISchema, EmployeeSchema>();
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

builder.Services.AddGraphQL(b => b
    //.AddAutoSchema<EmployeeQuery>()  // schema
    .AddGraphTypes()
    // serializer
    .AddSystemTextJson());
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // Use GraphQL Playground
    app.UseGraphQLPlayground();

    // app.UseSwagger();
    // app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
 app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>("/graphql");            // url to host GraphQL endpoint
app.UseGraphQLPlayground(
    "/",                               // url to host Playground at
    new GraphQL.Server.Ui.Playground.PlaygroundOptions
    {
        GraphQLEndPoint = "/graphql",         // url of GraphQL endpoint
        SubscriptionsEndPoint = "/graphql",   // url of GraphQL endpoint
    });

app.Run();