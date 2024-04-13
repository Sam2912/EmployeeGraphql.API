using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace EmployeeGraphql.API.Types.Input
{
    public class PartTimeEmployeeInputType : BaseEmployeeInputType<PartTimeEmployeeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<PartTimeEmployeeInput> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(f => f.HourlyRate).Type<FloatType>().Description("Employee HourlyRate");
        }
    }
}