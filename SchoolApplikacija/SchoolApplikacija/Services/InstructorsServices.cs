using AutoMapper;
using SchoolApplikacija.Infrastructure;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SchoolApplikacija.Services
{
    public class InstructorsServices : IInstructorsServices
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public InstructorsServices(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InstructorDto>> GetInstructorsAsync()
        {
            var retVal = new List<InstructorDto>();
            try
            {
                var instructors = await _context.Instructors.Include(o => o.OfficeAssignment)
                        .Include(c => c.CourseAssignments)
                        .ThenInclude(c => c.Course)
                        .OrderBy(l => l.LastName)
                        .AsNoTracking()
                        .ToListAsync();

                var mapped = _mapper.Map<List<InstructorDto>>(instructors);

                retVal = mapped.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return retVal;
        }
    }
}