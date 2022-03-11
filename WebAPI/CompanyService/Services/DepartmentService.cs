using System.Collections.Generic;
using System.Threading.Tasks;
using CompanyService.Interfaces;
using DataAccess.Models;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace CompanyService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly CompanyDBContext _companyDB;
        public DepartmentService(CompanyDBContext companyDB)
        {
            _companyDB = companyDB;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = await _companyDB.Departments.ToListAsync();
            return departments;
        }

        public async Task<Department> GetDepartment(int? departmentId)
        {
            if (departmentId != null)
            {
                var department = await _companyDB.Departments.FindAsync(departmentId);
                return department;
            }
            return null;
        }

        public async Task<bool> AddDepartment(Department department)
        {
            if (department != null)
            {
                _companyDB.Departments.Add(department);
                var result = await _companyDB.SaveChangesAsync();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            _companyDB.Entry(department).State = EntityState.Modified;
            _companyDB.Update(department);
            var result = await _companyDB.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;
        }
        public async Task<bool> DeleteDepartment(int? departmentId)
        {
            var department = await _companyDB.Departments.FindAsync(departmentId);
            if (department != null)
            {
                _companyDB.Departments.Remove(department);
                var result = await _companyDB.SaveChangesAsync();
                if (result > 0)
                    return true;
            }
            return false;
        }


    }
}
