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
        private readonly WorkDBContext _workDB;
        public DepartmentService(WorkDBContext workDB)
        {
            _workDB = workDB;
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = await _workDB.Departments.ToListAsync();
            return departments;
        }

        public Department GetDepartment(int? departmentId)
        {
            if (departmentId != null)
            {
                var department = _workDB.Departments.Find(departmentId);
                return department;
            }
            return null;
        }

        public bool AddDepartment(Department department)
        {
            if (department != null)
            {
                _workDB.Departments.Add(department);
                var result = _workDB.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool UpdateDepartment(Department department)
        {
            _workDB.Entry(department).State = EntityState.Modified;
            var result = _workDB.SaveChanges();
            if (result > 0)
                return true;
            return false;
        }
        public bool DeleteDepartment(int? departmentId)
        {
            var department = _workDB.Departments.Find(departmentId);
            if (department != null)
            {
                _workDB.Departments.Remove(department);
                var result = _workDB.SaveChanges();
                if (result > 0)
                    return true;
            }
            return false;
        }


    }
}
