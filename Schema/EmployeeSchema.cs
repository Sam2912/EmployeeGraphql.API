namespace EmployeeGraphql.API.Schema
{
    using GraphQL.Types;

    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();
            // Mutation = serviceProvider.GetRequiredService<MyMutation>();
        }
    }
}

