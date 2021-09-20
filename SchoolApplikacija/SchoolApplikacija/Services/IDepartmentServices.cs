using SharedModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolApplikacija.Services
{
    public interface IDepartmentServices
    {
        Task<List<DepartmentDto>> GetListAsync();

        Task<DepartmentDto> GetByIDAsync(int? id);

        Task<bool> DepartmentUpdateAsync(DepartmentDto updatedDepartment);

        Task<bool> DepartmentAddAsync(DepartmentDto newDepartment);

        Task<bool> DeleteDepartmentsAsync(int? id);
    }
}