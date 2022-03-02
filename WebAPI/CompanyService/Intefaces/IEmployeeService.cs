using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.Models;

namespace CompanyService.Intefaces
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<Employee> GetEmployee(int? employeeId);
        public int AddEmployee(Employee employee);
        public int UpdateEmployee(Employee employee);
        public int DeleteEmployee(int? id);
    }
}
