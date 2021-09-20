using System;

namespace SharedModels
{
    public class DepartmentDto
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public int Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int InstructorID { get; set; }
        public string AdministratorFullName { get; set; }
    }
}