using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyService.Interfaces;
using DataAccess.Models;

namespace CompanyService.Services
{
    public class EmployeeService : IEmployeeService
    {
        int IEmployeeService.AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        int IEmployeeService.DeleteEmployee(int? id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Employee>> IEmployeeService.GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        Task<Employee> IEmployeeService.GetEmployee(int? employeeId)
        {
            throw new NotImplementedException();
        }

        int IEmployeeService.UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
