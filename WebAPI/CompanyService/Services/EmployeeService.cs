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
        private readonly CompanyDBContext _companyDB;
        public EmployeeService(CompanyDBContext companyDB)
        {
            _companyDB = companyDB;
        }
        public bool AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _companyDB.Employees.Add(employee);
                var result = _companyDB.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = await _companyDB.Employees.Include(emp=>emp.Department).ToListAsync();
            return employees; 
        }

        public Employee GetEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = _companyDB.Employees.Find(employeeId);
                return employee;
            }
            return null;
        }

        public bool UpdateEmployee(Employee employee)
        {
            _companyDB.Entry(employee).State = EntityState.Modified;
            var result = _companyDB.SaveChanges();
            if (result > 0)
                return true;
            return false; 
        }
        public bool DeleteEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = _companyDB.Employees.Find(employeeId);
                if (employee != null)
                {
                    _companyDB.Employees.Remove(employee);
                    var result = _companyDB.SaveChanges();
                    if (result > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
