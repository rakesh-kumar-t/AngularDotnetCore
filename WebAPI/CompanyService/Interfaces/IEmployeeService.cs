using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int? employeeId);
        Task<bool> AddEmployee(Employee employee);
        Task<bool> UpdateEmployee(Employee employee);
        Task<bool> DeleteEmployee(int? employeeId);
    }
}
