using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Input
{
    public class EmployeeInputType : InputObjectType<EmployeeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<EmployeeInput> descriptor)
        {
            descriptor.Field(f => f.FullTimeEmployeeType).Type<FullTimeEmployeeInputType>();
            descriptor.Field(f => f.PartTimeEmployeeType).Type<PartTimeEmployeeInputType>();

        }
    }
}