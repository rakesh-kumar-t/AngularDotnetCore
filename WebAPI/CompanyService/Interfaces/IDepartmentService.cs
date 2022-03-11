using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task<Department> GetDepartment(int? departmentId);
        Task<bool> AddDepartment(Department department);
        Task<bool> UpdateDepartment(Department department);
        Task<bool> DeleteDepartment(int? departmentId);
    }
}
