using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Intefaces
{
    public interface IDepartmentService
    {
        public Task<IEnumerable<Department>> GetAllDepartments();
        public Department GetDepartment(int? departmentId);
        public bool AddDepartment(Department department);
        public bool UpdateDepartment(Department department);
        public bool DeleteDepartment(int? departmentId);
    }
}
