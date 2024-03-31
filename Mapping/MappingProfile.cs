using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types;

namespace EmployeeGraphql.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FullTimeEmployeeInput, FullTimeEmployee>();
            CreateMap<PartTimeEmployeeInput, PartTimeEmployee>();

            
        }
    }
}