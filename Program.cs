using EmployeeGraphql.API;
using EmployeeGraphql.API.Schema;
using EmployeeGraphql.API.Services;
using GraphQL;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
// builder.Services.AddSingleton<EmployeeDetailsType>();
builder.Services.AddSingleton<EmployeeQuery>();
builder.Services.AddSingleton<ISchema, EmployeeSchema>();
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