using AutoMapper;
using SharedModels;

namespace SchoolApplikacija.Models.Mappings
{
    public class StudentDetailsMappingProfile : Profile
    {
        public StudentDetailsMappingProfile()
        {
            CreateMap<Student, StudentDetailsDto>();
        }
    }
}