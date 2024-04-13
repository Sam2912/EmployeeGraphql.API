using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeGraphql.API.Models;

namespace EmployeeGraphql.API.Types.Input
{
    public class BaseEmployeeInputType<T> : InputObjectType<T> where T : BaseEmployeeInput
    {
        protected override void Configure(IInputObjectTypeDescriptor<T> descriptor)
        {
            descriptor.Field(f=>f.Id).Type<IdType>().Description("Employee Id");
            descriptor.Field(f=>f.Name).Type<StringType>().Description("Employee Name");
            descriptor.Field(f=>f.Department).Type<DepartmentType>().Description("Employee Department");
            descriptor.Field(f=>f.Status).Type<StatusType>().Description("Employee Status");
            descriptor.Field(f=>f.Type).Type<EmployeeType>().Description("Employee Type");
        }
    }
}