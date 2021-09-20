using AutoMapper;
using SharedModels;

namespace SchoolApplikacija.Models.Mappings
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDto>();
            //.ForMember(d => d.AdministratorName, opt => opt.MapFrom(src => src.Administrator.FullName)) ;
        }
    }
}