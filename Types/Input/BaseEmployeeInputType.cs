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
            descriptor.Field(f=>f.Id).Type<IdType>();
            descriptor.Field(f=>f.Name).Type<StringType>();
            descriptor.Field(f=>f.Department).Type<DepartmentType>();
            descriptor.Field(f=>f.Status).Type<StatusType>();
            descriptor.Field(f=>f.Type).Type<EmployeeType>();
        }
    }
}