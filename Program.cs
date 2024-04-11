using EmployeeGraphql.API.Extensions;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using EmployeeGraphql.API.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((builder) =>
    {
         builder.RegisterModule(new AutofacModule());
    });

var configuration = builder.Configuration;

// Call extension methods to configure services
builder.Services.ConfigureDbContext(configuration);
builder.Services.ConfigureIdentity();
builder.Services.ConfigureAuthentication(configuration);
builder.Services.ConfigureAuthorization();
builder.Services.ConfigureCors();
//builder.Services.ConfigureServices();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureGraphQL();
builder.Services.ConfigureBackgroundService();
builder.Services.AddControllers();

var app = builder.Build();
var environment = builder.Environment;

app.UseCustomEndpoints(environment);
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseRouting();
app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllers();

app.MapGraphQL();

app.Run();