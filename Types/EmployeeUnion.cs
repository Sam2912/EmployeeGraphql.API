namespace EmployeeGraphql.API.Types
{
    public class EmployeeUnion : UnionType
    {
        protected override void Configure(IUnionTypeDescriptor descriptor)
        {
            descriptor.Name("EmployeeUnion")
                        .Type<PartTimeEmployeeType>()
                        .Type<FullTimeEmployeeType>();
        }
    }
}

