using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types
{
    public class StatusType : EnumType<Status>
    {
        protected override void Configure(IEnumTypeDescriptor<Status> descriptor)
        {
            descriptor.Name("Status")
            .Description("Employee status");
        }
    }
}