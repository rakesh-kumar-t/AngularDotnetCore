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
        public async Task<bool> AddEmployee(Employee employee)
        {
            if (employee != null)
            {
                _companyDB.Employees.Add(employee);
                var result = await _companyDB.SaveChangesAsync();
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

        public async Task<Employee> GetEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = await _companyDB.Employees.FindAsync(employeeId);
                return employee;
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _companyDB.Update(employee);
            var result = await _companyDB.SaveChangesAsync();
            if (result > 0)
                return true;
            return false; 
        }
        public async Task<bool> DeleteEmployee(int? employeeId)
        {
            if (employeeId != null)
            {
                var employee = await _companyDB.Employees.FindAsync(employeeId);
                if (employee != null)
                {
                    _companyDB.Employees.Remove(employee);
                    var result = await _companyDB.SaveChangesAsync();
                    if (result > 0)
                        return true;
                }
            }
            return false;
        }
    }
}
