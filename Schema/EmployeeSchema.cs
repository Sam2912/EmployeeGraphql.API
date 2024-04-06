namespace EmployeeGraphql.API.Schema
{
    using EmployeeGraphql.API.Mutation;
    using GraphQL.Types;

    public class EmployeeSchema : Schema
    {
        public EmployeeSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();

            Mutation = new ObjectGraphType { Name = "Mutations" };

            var employeeMutations = serviceProvider.GetRequiredService<EmployeeMutation>();
            var authMutations = serviceProvider.GetRequiredService<AuthorizationMutation>();

            Mutation.AddField(employeeMutations.GetField("addEmployee")); // Assuming GetField() returns the FieldDefinition
            Mutation.AddField(employeeMutations.GetField("updateEmployee")); // Assuming GetField() returns the FieldDefinition
            Mutation.AddField(employeeMutations.GetField("deleteEmployee")); // Assuming GetField() returns the FieldDefinition
            
            Mutation.AddField(authMutations.GetField("createRole")); // Assuming GetField() returns the FieldDefinition
            Mutation.AddField(authMutations.GetField("createUser")); // Assuming GetField() returns the FieldDefinition
            Mutation.AddField(authMutations.GetField("assignRolesToUser")); // Assuming GetField() returns the FieldDefinition 
        }
    }
}

