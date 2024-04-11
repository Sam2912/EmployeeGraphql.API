using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types
{
    public class FullTimeEmployeeType : ObjectType<FullTimeEmployee>
    {
        protected override void Configure(IObjectTypeDescriptor<FullTimeEmployee> descriptor)
        {
            descriptor.Field(e => e.Id).Type<NonNullType<IdType>>().Name("id");
            descriptor.Field(e => e.Name).Type<StringType>().Name("name");
            descriptor.Field(e => e.Department).Name("department");
            descriptor.Field(e => e.Status).Name("status");
            descriptor.Field(e => e.Type).Name("type");
            descriptor.Field(e => e.Salary).Type<DecimalType>().Name("salary");
            descriptor.Implements<IEmployeeType>();
        }
    }

}

