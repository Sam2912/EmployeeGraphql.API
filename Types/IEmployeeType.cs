using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types
{
    public class IEmployeeType : InterfaceType<IEmployee>
    {
        protected override void Configure(IInterfaceTypeDescriptor<IEmployee> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Name("IEmployee");
            descriptor.Field(e => e.Id).Type<NonNullType<IdType>>().Name("id");
            descriptor.Field(e => e.Name).Type<StringType>().Name("name");
            descriptor.Field(e => e.Department).Name("department");
            descriptor.Field(e => e.Status).Name("status");
            descriptor.Field(e => e.Type).Name("type");
        }
    }
}