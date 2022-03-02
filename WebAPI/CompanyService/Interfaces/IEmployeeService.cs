using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Employee GetEmployee(int? employeeId);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int? employeeId);
    }
}
