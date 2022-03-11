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

        public Department GetDepartment(int? departmentId)
        {
            if (departmentId != null)
            {
                var department = _companyDB.Departments.Find(departmentId);
                return department;
            }
            return null;
        }

        public bool AddDepartment(Department department)
        {
            if (department != null)
            {
                _companyDB.Departments.Add(department);
                var result = _companyDB.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateDepartment(Department department)
        {
            _companyDB.Entry(department).State = EntityState.Modified;
            var result = _companyDB.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }
        public bool DeleteDepartment(int? departmentId)
        {
            var department = _companyDB.Departments.Find(departmentId);
            if (department != null)
            {
                _companyDB.Departments.Remove(department);
                var result = _companyDB.SaveChanges();
                if (result > 0)
                    return true;
            }
            return false;
        }


    }
}
