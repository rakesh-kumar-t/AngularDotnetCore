using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Department GetDepartment(int? departmentId);
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int? departmentId);
    }
}
