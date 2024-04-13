using AutoMapper;
using EmployeeGraphql.API.Models;
using EmployeeGraphql.API.Types.Input;

namespace EmployeeGraphql.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FullTimeEmployeeInput, FullTimeEmployee>()
                    .ForMember(dest => dest.Type, opt => opt.Ignore());

            CreateMap<PartTimeEmployeeInput, PartTimeEmployee>()
                    .ForMember(dest => dest.Type, opt => opt.Ignore());
        }
    }
}