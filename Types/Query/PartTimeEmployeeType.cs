using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types.Query
{
    public class PartTimeEmployeeType : ObjectType<PartTimeEmployee>
    {
        protected override void Configure(IObjectTypeDescriptor<PartTimeEmployee> descriptor)
        {
            descriptor.Field(e => e.Id).Type<NonNullType<IdType>>().Name("id");
            descriptor.Field(e => e.Name).Type<StringType>().Name("name");
            descriptor.Field(e => e.Department).Name("department");
            descriptor.Field(e => e.Status).Name("status");
            descriptor.Field(e => e.Type).Name("type");
            descriptor.Field(e => e.HourlyRate).Type<DecimalType>().Name("hourlyRate");
            descriptor.Implements<IEmployeeType>();
        }

    }

}

