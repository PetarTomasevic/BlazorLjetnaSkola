using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolApplikacija.Infrastructure;
using SchoolApplikacija.Models;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApplikacija.Services
{
    public class DepartmentsService : IDepartmentServices
    {
        private readonly SchoolContext _context;
        private readonly IMapper _mapper;

        public DepartmentsService(SchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDto>> GetListAsync()
        {
            var retVal = new List<DepartmentDto>();
            try
            {
                var departments = await _context.Departments
                                  .Include(a => a.Administrator)
                                  .AsNoTracking()
                                  .ToListAsync();
                var mapped = _mapper.Map<List<DepartmentDto>>(departments);

                retVal = mapped.ToList();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return retVal;
        }

        public async Task<DepartmentDto> GetByIDAsync(int? id)
        {
            var retVal = new DepartmentDto();

            try
            {
                var department = await _context.Departments.Include(a => a.Administrator)
                        .AsNoTracking().SingleOrDefaultAsync(m => m.DepartmentID == id);

                retVal = _mapper.Map<DepartmentDto>(department);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return retVal;
        }

        public async Task<bool> DepartmentUpdateAsync(DepartmentDto updatedDepartment)
        {
            var retVal = false;
            try
            {
                var departmentToUpdate = await _context.Departments.FindAsync(updatedDepartment.DepartmentID);
                if (departmentToUpdate == null)
                {
                    return false;
                }

                departmentToUpdate.Budget = updatedDepartment.Budget;
                departmentToUpdate.InstructorID = updatedDepartment.InstructorID;
                departmentToUpdate.Name = updatedDepartment.Name;
                departmentToUpdate.StartDate = updatedDepartment.StartDate;

                _context.Departments.Update(departmentToUpdate);
                await _context.SaveChangesAsync();

                retVal = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return retVal;
        }

        public async Task<bool> DepartmentAddAsync(DepartmentDto newDepartment)
        {
            var retVal = false;
            try
            {
                var departmentToCreate = new Department
                {
                    Budget = newDepartment.Budget,
                    Name = newDepartment.Name,
                    StartDate = newDepartment.StartDate,
                    InstructorID = newDepartment.InstructorID,
                };
                _context.Add(departmentToCreate);
                await _context.SaveChangesAsync();
                retVal = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return retVal;
        }

        public async Task<bool> DeleteDepartmentsAsync(int? id)
        {
            var retVal = false;
            try
            {
                var department = await _context.Departments.FindAsync(id);
                if (department == null)
                {
                    return retVal;
                }
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                retVal = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            return retVal;
        }
    }
}