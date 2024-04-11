using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types
{
    public class EmployeeType : EnumType<Employee>
    {
        protected override void Configure(IEnumTypeDescriptor<Employee> descriptor)
        {
            descriptor.Name("type")
                    .Description("Employee Type");
        }
    }
}