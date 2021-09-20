using AutoMapper;
using SharedModels;

namespace SchoolApplikacija.Models.Mappings
{
    public class CourseMappingProfile : Profile
    {
        public CourseMappingProfile()
        {
            CreateMap<Course, CourseDto>().ForMember(m => m.Id, opt => opt.MapFrom(src => src.CourseID));
            CreateMap<CourseDto, Course>().ForMember(m => m.CourseID, opt => opt.MapFrom(src => src.Id));
        }
    }
}