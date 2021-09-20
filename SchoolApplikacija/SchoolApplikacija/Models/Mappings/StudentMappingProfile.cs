using AutoMapper;
using SharedModels;

namespace SchoolApplikacija.Models.Mappings
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}