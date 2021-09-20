using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplikacija.Services
{
    public interface IInstructorsServices
    {
        Task<List<InstructorDto>> GetInstructorsAsync();
    }
}