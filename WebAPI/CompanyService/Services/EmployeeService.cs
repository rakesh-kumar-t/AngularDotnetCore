using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyService.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly WorkDBContext _workDB;
        public EmployeeService(WorkDBContext workDB)
        {
            _workDB = workDB;
        }
        public bool AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _workDB.Employees.Add(employee);
                var result = _workDB.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _workDB.Employees.Include(emp=>emp.Department).ToListAsync();
            return employees; 
        }

        public Employee GetEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = _workDB.Employees.Find(employeeId);
                return employee;
            }
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _workDB.Entry(employee).State = EntityState.Modified;
            var result = _workDB.SaveChanges();
            if (result > 0)
                return true;
            return false; 
        }
        public bool DeleteEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = _workDB.Employees.Find(employeeId);
                if (employee != null)
                {
                    _workDB.Employees.Remove(employee);
                    var result = _workDB.SaveChanges();
                    if (result > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
