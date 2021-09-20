using System.Collections.Generic;

namespace SharedModels
{
    public class StudentDetailsDto : StudentDto
    {
        public List<EnrollmentDto> Enrollments { get; set; }
    }
}