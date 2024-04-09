using GraphQL.Types;
using EmployeeGraphql.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Call extension methods to configure services
builder.Services.ConfigureDbContext(configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAuthentication(configuration);
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureCors();
builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureGraphQL();
builder.Services.ConfigureBackgroundService();
 
var app = builder.Build();
var environment = builder.Environment;

app.UseCustomEndpoints(environment);
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllers();

app.UseGraphQL<ISchema>("/graphql");



app.Run();