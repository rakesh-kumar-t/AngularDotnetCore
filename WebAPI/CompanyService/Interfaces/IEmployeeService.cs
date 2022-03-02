using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployee(int? employeeId);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(int? id);
    }
}
