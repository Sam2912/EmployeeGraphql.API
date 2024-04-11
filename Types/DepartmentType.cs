using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types
{
    public class DepartmentType : EnumType<Department>
    {
        protected override void Configure(IEnumTypeDescriptor<Department> descriptor)
        {
            descriptor.Name("Department")
            .Description("Employee Department");
        }
    }
}