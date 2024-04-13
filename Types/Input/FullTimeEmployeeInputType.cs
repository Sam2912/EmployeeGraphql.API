using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeGraphql.API.Types.Input
{
    public class FullTimeEmployeeInputType : BaseEmployeeInputType<FullTimeEmployeeInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FullTimeEmployeeInput> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Field(f => f.Salary).Type<FloatType>().Description("Employee Salary");;
        }
    }
}
