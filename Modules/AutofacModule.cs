namespace EmployeeGraphql.API.Modules
{
    using System.Reflection;
    using Autofac;
    using EmployeeGraphql.API.Authorization;
    using EmployeeGraphql.API.Models;
    using EmployeeGraphql.API.Mutation;
    using EmployeeGraphql.API.Repositories;
    using EmployeeGraphql.API.Resolver;
    using EmployeeGraphql.API.Schema;
    using EmployeeGraphql.API.Services;
    using GraphQL.Types;

    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Register your services here
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();

            // Add services to the container.
            builder.RegisterType<EmployeeResolver>().As<IEmployeeResolver>().InstancePerLifetimeScope();
            //builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

            builder.RegisterType<EmployeeQuery>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeMutation>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AuthorizationMutation>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeSchema>().As<ISchema>().InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<MyUserContext>().AsSelf().InstancePerLifetimeScope();


            // Define the namespace where your services are located
            string serviceNamespace = "EmployeeGraphql.API.Services";
            // Get the assembly containing your services
            var assembly = Assembly.GetExecutingAssembly();
            // Register services based on the naming convention
            RegisterServices(builder, assembly, serviceNamespace);
        }

        private void RegisterServices(ContainerBuilder builder, Assembly assembly, string serviceNamespace)
        {
            var services = assembly.GetTypes()
                                   .Where(t => t.IsClass && t.Namespace == serviceNamespace && t.Name.EndsWith("Service"));

            foreach (var serviceType in services)
            {
                // Register the service with the Autofac container
                builder.RegisterType(serviceType).AsImplementedInterfaces().InstancePerLifetimeScope();
            }
        }
    }

}